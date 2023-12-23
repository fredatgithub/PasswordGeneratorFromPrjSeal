using NUnit.Framework;
using System.Text.RegularExpressions;
using System;

namespace PasswordGenerator.Tests
{
  public class ObsoleteTests
  {
    [Test]
    [Obsolete]
    public void PasswordGenerator_GivenNoSettings_ShouldReturn16Length()
    {
      var pwdGen = new PasswordGenerator();
      string result = pwdGen.Next();
      Assert.AreEqual(16, result.Length);
    }

    [Test]
    [Obsolete]
    public void PasswordGenerator_GivenLength3_ShouldReturnLengthErrorMessage()
    {
      var pwdGen = new PasswordGenerator(3);
      string result = pwdGen.Next();
      Assert.AreEqual("Password length invalid. Must be between 4 and 256 characters long", result);
    }

    [Test]
    [Obsolete]
    public void PasswordGenerator_GivenLength257_ShouldReturnLengthErrorMessage()
    {
      var pwdGen = new PasswordGenerator(257);
      string result = pwdGen.Next();
      Assert.AreEqual("Password length invalid. Must be between 4 and 256 characters long", result);
    }

    [Test]
    [Obsolete]
    public void PasswordGenerator_GivenLength256_ShouldReturn256Length()
    {
      var pwdGen = new PasswordGenerator(256);
      string result = pwdGen.Next();
      Assert.AreEqual(256, result.Length);
    }

    [Test]
    [Obsolete]
    public void PasswordGenerator_IncludeLowercase_ShouldReturn16Length()
    {
      var pwdGen = new PasswordGenerator().IncludeLowercase();
      string result = pwdGen.Next();
      Assert.AreEqual(16, result.Length);
    }

    [Test]
    [Obsolete]
    public void PasswordGenerator_LengthRequired50_ShouldReturn50Length()
    {
      var pwdGen = new PasswordGenerator().LengthRequired(50);
      string result = pwdGen.Next();
      Assert.AreEqual(50, result.Length);
    }

    [Test]
    [Obsolete]
    public void PasswordGenerator_16DigitNumeric_ShouldReturn16DigitNumericOnlyPassword()
    {
      var pwdGen = new PasswordGenerator().IncludeNumeric();
      var result = pwdGen.Next();
      var pattern = @"^\d{16}$";
      var m = Regex.Match(result, pattern, RegexOptions.IgnoreCase);
      Assert.IsTrue(m.Success);
    }

    [Test]
    [Obsolete]
    public void PasswordGenerator_16DigitLowercase_ShouldReturn16DigitLowercaseOnlyPassword()
    {
      var pwdGen = new PasswordGenerator().IncludeLowercase();
      var result = pwdGen.Next();
      var pattern = @"^[a-z]{16}$";
      var m = Regex.Match(result, pattern, RegexOptions.IgnoreCase);
      Assert.IsTrue(m.Success);
    }
  }
}