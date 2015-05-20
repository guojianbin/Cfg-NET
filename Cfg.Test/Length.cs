﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using Transformalize.Libs.Cfg.Net;
using Transformalize.Libs.Cfg.Net.Loggers;

namespace Cfg.Test {

    [TestFixture]
    public class Length {

        [Test]
        public void TestXml() {
            var xml = @"
    <test>
        <things>
            <add value='too-short' />
            <add value='this-is-way-too-long' />
            <add value='just-right' />
        </things>
    </test>
".Replace("'", "\"");

            var cfg = new TestLength(xml);

            foreach (var problem in cfg.Errors()) {
                Console.WriteLine(problem);
            }

            var problems = cfg.Errors();
            Assert.AreEqual(2, problems.Length);
            Assert.IsTrue(problems[0] == "The 'value' attribute value 'too-short' is too short. It is 9 characters. It must be at least 10 characters.");
            Assert.IsTrue(problems[1] == "The 'value' attribute value 'this-is-way-too-long' is too long. It is 20 characters. It must not exceed 15 characters.");

        }

        [Test]
        public void TestJson() {
            var json = @"{
        'things':[
            { 'value':'too-short' },
            { 'value':'this-is-way-too-long' },
            { 'value':'just-right' }
        ]
    }
".Replace("'", "\"");

            var cfg = new TestLength(json);

            foreach (var problem in cfg.Errors()) {
                Console.WriteLine(problem);
            }

            var problems = cfg.Errors();
            Assert.AreEqual(2, problems.Length);
            Assert.IsTrue(problems[0] == "The 'value' attribute value 'too-short' is too short. It is 9 characters. It must be at least 10 characters.");
            Assert.IsTrue(problems[1] == "The 'value' attribute value 'this-is-way-too-long' is too long. It is 20 characters. It must not exceed 15 characters.");

        }

    }

    public class TestLength : CfgNode {
        [Cfg()]
        public List<LengthThing> Things { get; set; }
        public TestLength(string xml) {
            Load(xml);
        }
    }

    public class LengthThing : CfgNode {
        [Cfg(minLength = 10, maxLength = 15)]
        public string Value { get; set; }
    }

}
