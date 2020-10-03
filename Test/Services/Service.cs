using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.Data;

namespace Test.Services
{
    public abstract class Service
    {
        public TestContext Context { get; set; }
        public Service(TestContext context)
        {
            this.Context = context;
        }
    }
}