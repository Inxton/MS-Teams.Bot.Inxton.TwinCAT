// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Teams;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TcoCore;
using TeamsPlc;

namespace Microsoft.BotBuilderSamples.Bots
{
    public class TeamsConversationBot : TeamsActivityHandler
    {
        private string _appId;
        private string _appPassword;
        private PlcTwin PlcTwin;

        public TeamsConversationBot(IConfiguration config, PlcTwin plcTwin)
        {
            _appId = config["MicrosoftAppId"];
            _appPassword = config["MicrosoftAppPassword"];
            PlcTwin = plcTwin;
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var messageFromTeams = turnContext.Activity.Text.Trim();

            if (TaskNames.Contains(messageFromTeams))
                await InvokeTaskInPlc(turnContext, messageFromTeams, cancellationToken);
            else
                await CardActivityAsync(turnContext, false, cancellationToken);
        }


        private IEnumerable<string> TaskNames => typeof(TeamsApp)
                .GetProperties()
                .Where(x => x.PropertyType == typeof(TcoTask))
                .Select(x => x.Name);

        private async Task CardActivityAsync(ITurnContext<IMessageActivity> turnContext, bool update, CancellationToken cancellationToken)
        {
            var tasks = TaskNames
                .Select(name => new CardAction
                {
                    Type = ActionTypes.MessageBack,
                    Title = name,
                    Text = name
                });

            var card = new HeroCard
            {
                Buttons = tasks.ToList()
            };

            await SendCard(turnContext, card, cancellationToken);
        }

        private async Task InvokeTaskInPlc(ITurnContext<IMessageActivity> turnContext, string messageText, CancellationToken cancellationToken)
        {
            var message = MessageFactory.Text(messageText);
            await turnContext.SendActivityAsync(message);
            var app = PlcTwin.TeamsPlcTwin.MAIN.App;
            var task = app.GetType().GetProperty(messageText).GetValue(app) as TcoTask;
            task.Execute(null);
            var taskResult = await TaskIsDone(task, cancellationToken);
            if (taskResult == eTaskState.Done)
            {
                await turnContext.SendActivityAsync($"Status of the machine {app.IsMachineRunning.Synchron}");
            }
            else
            {
                await turnContext.SendActivityAsync($"An error occured");
            }
        }

        private Task<eTaskState> TaskIsDone(TcoTask task, CancellationToken cancellationToken) => Task.Run(async () =>
        {
            while (true)
            {
                await Task.Delay(PlcTwin.TeamsPlcTwin.Connector.ReadWriteCycleDelay);
                var taskState = (eTaskState)task._taskState.Cyclic;
                if (taskState == eTaskState.Done)
                    return taskState;
                if (taskState == eTaskState.Error)
                    return taskState;
            }
        }, cancellationToken);

        private static async Task SendCard(ITurnContext<IMessageActivity> turnContext, HeroCard card, CancellationToken cancellationToken)
        {
            card.Title = "Welcome to my TEAMS PLC demo!";
            var activity = MessageFactory.Attachment(card.ToAttachment());
            await turnContext.SendActivityAsync(activity, cancellationToken);
        }

    }
}
