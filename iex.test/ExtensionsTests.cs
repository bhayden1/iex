using System.Collections.Generic;
using NUnit.Framework;
using FluentAssertions;

namespace iex.test
{
  [TestFixture]
  public class ExtensionsTests
  {
    [TestCase("Name")]
    [TestCase("Company")]
    [TestCase("Number")]
    [TestCase("Active")]
    [TestCase("Name,Company,Number,Active")]
    public void ToCsv_Adds_Headers_When_Asked(string expected)
    {
      var data = GenerateData();
      var results = data.ToCsv(true);
      results.Should().Contain(expected);
    }

    [TestCase("True")]
    [TestCase("Company 1")]
    [TestCase("Name 1")]
    [TestCase("100")]
    [TestCase("Name 1,Company 1,100,True")]
    public void ToCsv_Adds_Comma_Delimited_Data(string expected)
    {
      var data = GenerateData();
      var results = data.ToCsv(true);
      results.Should().Contain(expected);
    }

    public List<ExtensionTest> GenerateData()
    {
      return new List<ExtensionTest>
      {
        new ExtensionTest {Active = true, Company = "Company 1", Name = "Name 1", Number = 100},
      };
    }
  }

  public class ExtensionTest
  {
    public string Name { get; set; }
    public string Company { get; set; }
    public int Number { get; set; }
    public bool Active { get; set; }
  }
}
