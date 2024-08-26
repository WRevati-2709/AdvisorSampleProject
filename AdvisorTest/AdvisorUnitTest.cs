namespace AdvisorTest
{
    public class AdvisorUnitTest
    {
        [Fact]
        public void SaveAsync_Advisor_RightRecord()
        {
            TestHelper testHelper = new TestHelper();
            var advisorRepositary = testHelper.GetInMemoryAdvisorRepository();
            advisorRepositary.PostAdvisor(new Advisor.Domain.Advisor()
            {
                Id = 1,
                Name= "test",
                SIN= "226-600-259",
                Address="asd fgh jkl",
                Phone = "21436587",
                HealthStatus="Green"
            });

            var result = advisorRepositary.GetAdvisor(1).Result;
            // Assert
            Assert.NotNull(result);
            Assert.Equal("test", result.Name);
            Assert.Equal("226-600-259", result.SIN);
            Assert.Equal("asd fgh jkl", result.Address);
            Assert.Equal("21436587", result.Phone);
            Assert.Equal("Green", result.HealthStatus);

        }
    }
}