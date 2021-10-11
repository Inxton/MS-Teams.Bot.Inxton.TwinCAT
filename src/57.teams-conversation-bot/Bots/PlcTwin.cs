// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using TeamsPlc;
using Vortex.Adapters.Connector.Tc3.Adapter;

namespace Microsoft.BotBuilderSamples
{
    public class PlcTwin
    {
        public PlcTwin()
        {
            TeamsPlcTwin.Connector.BuildAndStart();

        }

        public TeamsPlcTwinController TeamsPlcTwin
            = new TeamsPlcTwinController(Tc3ConnectorAdapter.Create(null, 851, true));
    }
}
