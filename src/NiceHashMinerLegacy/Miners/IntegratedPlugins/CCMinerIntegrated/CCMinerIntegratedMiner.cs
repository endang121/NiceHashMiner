﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NiceHashMinerLegacy.Common;
using NiceHashMinerLegacy.Common.Enums;

namespace NiceHashMiner.Miners.IntegratedPlugins
{
    class CCMinerIntegratedMiner : MinerPluginToolkitV1.CCMinerCommon.CCMinerBase
    {
        public CCMinerIntegratedMiner(string uuid, string dirPath) : base(uuid)
        {
            _noTimeLimitOption = "ccminer_klaust" == dirPath;
        }

#pragma warning disable 0618
        protected override string AlgorithmName(AlgorithmType algorithmType)
        {
            switch (algorithmType)
            {
                case AlgorithmType.NeoScrypt: return "neoscrypt";
                case AlgorithmType.Blake2s: return "blake2s";
                case AlgorithmType.Keccak: return "keccak";
                case AlgorithmType.Skunk: return "skunk";
                case AlgorithmType.X16R: return "x16r";
                case AlgorithmType.Lyra2REv3: return "lyra2v3";
                case AlgorithmType.MTP: return "mtp";
            }
            // TODO throw exception
            return "";
        }
#pragma warning restore 0618

        public override Tuple<string, string> GetBinAndCwdPaths()
        {
            if (_uuid != "CCMinerTpruvot")
            {
                return base.GetBinAndCwdPaths();
            }

            var pluginRootBins = Paths.MinerPluginsPath(_uuid, "bins");
            var binPath = Path.Combine(pluginRootBins, "ccminer-x64.exe");
            return Tuple.Create(binPath, pluginRootBins);
        }
    }
}