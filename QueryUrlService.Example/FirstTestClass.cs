using QponyWP.Services.QueryUrlService;

namespace QueryUrlService.Example
{
    class FirstTestClass
    {
        [QueryProperty("string")]
        public string TestString { get; set; }

        [QueryProperty("int")]
        public int TestInt { get; set; }

        [QueryIgnore]
        public int IgnoredProperty { get; set; }
    }
}
