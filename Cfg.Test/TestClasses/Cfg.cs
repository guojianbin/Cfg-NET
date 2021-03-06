﻿#region license
// Cfg.Net
// An Alternative .NET Configuration Handler
// Copyright 2015-2017 Dale Newman
//  
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   
//       http://www.apache.org/licenses/LICENSE-2.0
//   
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion
using System.Collections.Generic;
using Cfg.Net;
using Cfg.Net.Contracts;

namespace Cfg.Test.TestClasses {

    public sealed class Cfg : CfgNode {

        [Cfg(required = true)]
        public List<CfgServer> Servers { get; set; }

        public Cfg(string cfg, IParser parser):base(parser) {
            Load(cfg);
        }

    } 
}