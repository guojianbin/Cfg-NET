﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using Transformalize.Libs.Cfg.Net;

namespace Cfg.Test {

    [TestFixture]
    public class Value {

        [Test]
        public void TestXml() {
            var xml = @"
    <test>
        <things>
            <add value='5' longValue='5' stringValue='1' />
            <add value='10' longValue='10' stringValue='2'/>
            <add value='15' longValue='15' stringValue='6'/>
        </things>
    </test>
".Replace("'", "\"");

            var cfg = new TestValue(xml);

            foreach (var problem in cfg.Problems()) {
                Console.WriteLine(problem);
            }

            var problems = cfg.Problems();
            Assert.AreEqual(3, problems.Count);
            Assert.IsTrue(problems.Contains("The `value` attribute's value `5` is too small. The minimum value allowed is `6`."));
            Assert.IsTrue(problems.Contains("The `longValue` attribute's value `5` is too small. The minimum value allowed is `6`."));
            Assert.IsTrue(problems.Contains("The `stringValue` attribute's value `6` is too big. The maximum value allowed is `5`."));

        }

        [Test]
        public void TestJson() {
            var json = @"{
        'things':[
            { 'value':5, 'longValue':5, 'stringValue':'1' },
            { 'value':10, 'longValue':10, 'stringValue':'2' },
            { 'value':15, 'longValue':15, 'stringValue':'6' }
        ]
    }
".Replace("'", "\"");

            var cfg = new TestValue(json);

            foreach (var problem in cfg.Problems()) {
                Console.WriteLine(problem);
            }

            var problems = cfg.Problems();
            Assert.AreEqual(3, problems.Count);
            Assert.IsTrue(problems.Contains("The `value` attribute's value `5` is too small. The minimum value allowed is `6`."));
            Assert.IsTrue(problems.Contains("The `longValue` attribute's value `5` is too small. The minimum value allowed is `6`."));
            Assert.IsTrue(problems.Contains("The `stringValue` attribute's value `6` is too big. The maximum value allowed is `5`."));

        }

    }

    public class TestValue : CfgNode {
        [Cfg()]
        public List<ValueThing> Things { get; set; }

        public TestValue(string xml) {
            Load(xml);
        }
    }

    public class ValueThing : CfgNode {

        [Cfg(minValue = 6, maxValue = 15)]
        public int Value { get; set; }

        [Cfg(minValue = 6, maxValue = 15)]
        public long LongValue { get; set; }

        [Cfg(minValue = 1, maxValue = 5)]
        public string StringValue { get; set; }
    }

}