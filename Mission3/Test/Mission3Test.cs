using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Mission3.Tests
{
    public class Mission3Tests
    {
        [Test]
        public void CalculateRisk_ReturnsRiskRatingResponse()
        {
            // Arrange
            var controller = new Mission3Controller();
            var request = new RiskCalculationRequest { claimHistory = "This car has crash, scratches and bumps" };

            // Act
            var response = controller.CalculateRisk(request);

            // Assert
            Assert.IsInstanceOf(typeof(OkObjectResult), response.Result);
            var result = (OkObjectResult)response.Result;
            Assert.IsInstanceOf(typeof(RiskRatingResponse), result.Value);
            var riskRatingResponse = (RiskRatingResponse)result.Value;
            Assert.AreEqual(3, riskRatingResponse.Risk_Rating);
        }

        [Test]
        public void CalculateRisk_ReturnsBadRequest_WhenClaimHistoryIsEmpty()
        {
            // Arrange
            var controller = new Mission3Controller();
            var request = new RiskCalculationRequest { claimHistory = "" };

            // Act
            var response = controller.CalculateRisk(request);

            // Assert
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), response.Result);
            var result = (BadRequestObjectResult)response.Result;
            Assert.AreEqual("Claim history cannot be empty", result.Value);
        }

        [Test]
        public void CalculateRisk_ReturnsRiskRatingResponse_WhenClaimHistoryContainsNoRiskWords()
        {
            // Arrange
            var controller = new Mission3Controller();
            var request = new RiskCalculationRequest { claimHistory = "This claim history contains no risk words" };

            // Act
            var response = controller.CalculateRisk(request);

            // Assert
            Assert.IsInstanceOf(typeof(OkObjectResult), response.Result);
            var result = (OkObjectResult)response.Result;
            Assert.IsInstanceOf(typeof(RiskRatingResponse), result.Value);
            var riskRatingResponse = (RiskRatingResponse)result.Value;
            Assert.AreEqual(0, riskRatingResponse.Risk_Rating);
        }

        [Test]
        public void CalculateRisk_ReturnsRiskRatingResponse_WhenClaimHistoryContainsMultipleOccurrencesOfRiskWords()
        {
            // Arrange
            var controller = new Mission3Controller();
            var request = new RiskCalculationRequest { claimHistory = "My car has crashed and left a scratch because I bumped with another car whom I collided with and smashed together leaving a scratch on the front" };

            // Act
            var response = controller.CalculateRisk(request);

            // Assert
            Assert.IsInstanceOf(typeof(OkObjectResult), response.Result);
            var result = (OkObjectResult)response.Result;
            Assert.IsInstanceOf(typeof(RiskRatingResponse), result.Value);
            var riskRatingResponse = (RiskRatingResponse)result.Value;
            Assert.AreEqual(5, riskRatingResponse.Risk_Rating);
        }

        [Test]
        public void CalculateRisk_ReturnsRiskRatingResponse_WhenClaimHistoryContainsNumbers()
        {
            // Arrange
            var controller = new Mission3Controller();
            var request = new RiskCalculationRequest { claimHistory = "33243243243242" };

            // Act
            var response = controller.CalculateRisk(request);

            // Assert
            Assert.IsInstanceOf(typeof(OkObjectResult), response.Result);
            var result = (OkObjectResult)response.Result;
            Assert.IsInstanceOf(typeof(RiskRatingResponse), result.Value);
            var riskRatingResponse = (RiskRatingResponse)result.Value;
            Assert.AreEqual(0, riskRatingResponse.Risk_Rating);
}
    }

    
}

