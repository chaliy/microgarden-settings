using MicroGarden.Settings.Core.Data;
using System;
using Xunit;

namespace MicroGarden.Settings.Core.Tests.Data
{
    public class DataMergerTests
    {
        [Fact]
        public void Should_merge_two_objects()
        {
            var a = new
            {
                Field1 = "Test"
            };

            var b = new
            {
                Field2 = "Test"
            };

            dynamic result = DataMerger.Merge(a, b);

            Assert.NotNull(result.Field1);
            Assert.NotNull(result.Field2);            
        }

        [Fact]
        public void Should_merge_two_objects_recursive()
        {
            var a = new
            {
                Field1 = new
                {
                    Field11 = "Test"
                }
            };

            var b = new
            {
                Field1 = new
                {
                    Field12 = "Test"
                },
                Field2 = "Test"
            };

            dynamic result = DataMerger.Merge(a, b);

            
            Assert.NotNull(result.Field1.Field11);
            Assert.NotNull(result.Field1.Field12);            
        }
    }
}
