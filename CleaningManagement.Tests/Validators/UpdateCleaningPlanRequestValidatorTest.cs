using CleaningManagement.Api.Models;
using CleaningManagement.Api.Validators;
using NUnit.Framework;

namespace CleaningManagement.Tests.Validators
{
    public class UpdateCleaningPlanRequestValidatorTest
    {
        private readonly UpdateCleaningPlanRequestValidator _validator = new();
        
        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("       ")]
        public void Title_WithEmptyOrWhiteSpaceValue_ShouldBeIsNotValid(string title)
        {
            // Arrange
            var request = new UpdateCleaningPlanRequest(title, 1, "Description");
            
            // Act
            var validationResult = _validator.Validate(request);
            
            // Assert
            Assert.IsFalse(validationResult.IsValid);
        }
        
        [Test]
        public void Title_WithLengthMoreThanMaxLength_ShouldBeIsNotValid()
        {
            // Arrange
            var maxLength = 256;
            var title = "title".PadRight(maxLength + 1);
            var request = new UpdateCleaningPlanRequest(title, 1, "Description");
            
            // Act
            var validationResult = _validator.Validate(request);
            
            // Assert
            Assert.IsFalse(validationResult.IsValid);
        }
        
        [Test]
        [TestCase("title")]
        [TestCase("correct test")]
        [TestCase("text")]
        public void Title_NotEmptyWithValidLength_ShouldBeIsValid(string title)
        {
            // Arrange
            var request = new UpdateCleaningPlanRequest(title, 1, "Description");
            
            // Act
            var validationResult = _validator.Validate(request);
            
            // Assert
            Assert.IsTrue(validationResult.IsValid);
        }
        
        [Test]
        public void CustomerId_LessThanZero_ShouldBeIsNotValid()
        {
            // Arrange
            var request = new UpdateCleaningPlanRequest("Title", -1, "Description");
            
            // Act
            var validationResult = _validator.Validate(request);
            
            // Assert
            Assert.IsFalse(validationResult.IsValid);
        }
        
        [Test]
        public void CustomerId_EqualZero_ShouldBeIsNotValid()
        {
            // Arrange
            var request = new UpdateCleaningPlanRequest("Title", 0, "Description");
            
            // Act
            var validationResult = _validator.Validate(request);
            
            // Assert
            Assert.IsFalse(validationResult.IsValid);
        }
        
        [Test]
        public void CustomerId_MoreThanZero_ShouldBeIsValid()
        {
            // Arrange
            var request = new UpdateCleaningPlanRequest("Title", 1, "Description");
            
            // Act
            var validationResult = _validator.Validate(request);
            
            // Assert
            Assert.IsTrue(validationResult.IsValid);
        }
        
        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("       ")]
        public void Description_WithEmptyOrWhiteSpaceValue_ShouldBeIsValid(string description)
        {
            // Arrange
            var request = new UpdateCleaningPlanRequest("Title", 1, description);
            
            // Act
            var validationResult = _validator.Validate(request);
            
            // Assert
            Assert.IsTrue(validationResult.IsValid);
        }
        
        [Test]
        public void Description_WithLengthMoreThanMaxLength_ShouldBeIsNotValid()
        {
            // Arrange
            var maxLength = 512;
            var description = "description".PadRight(maxLength + 1);
            var request = new UpdateCleaningPlanRequest("Title", 1, description);
            
            // Act
            var validationResult = _validator.Validate(request);
            
            // Assert
            Assert.IsFalse(validationResult.IsValid);
        }
        
        [Test]
        [TestCase("Description")]
        [TestCase("correct test")]
        [TestCase("text")]
        public void Description_NotEmptyWithValidLength_ShouldBeIsValid(string description)
        {
            // Arrange
            var request = new UpdateCleaningPlanRequest("Title", 1, description);
            
            // Act
            var validationResult = _validator.Validate(request);
            
            // Assert
            Assert.IsTrue(validationResult.IsValid);
        }
    }
}