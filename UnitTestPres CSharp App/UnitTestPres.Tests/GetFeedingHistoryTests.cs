using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace UnitTestPres.Tests
{
    public class GetFeedingHistoryTests
    {
        [Test]
        public void BuildFeedingHistory_Sucess()
        {
            #region Arrange
            //arrange
            //prod 1, comp 1, age 1
            FlatFeedingData row1 = new FlatFeedingData
            {
                ZooId = 1,
                ZooTypeNr = 5,
                ZooAnimalId = 1,
                AnimalCode = "Tiger24",
                AnimalName = "Simba",
                BirthdayDate = new System.DateTime(2016, 11, 01),
                FeedingID = "1",
                FeddingType = FeedingType.Lunch,
                FeedingDate = new System.DateTime(2019, 12, 01),
                Meal = "TurkeyBreast and Green Beans",
                AmountGiven = .75,
                AmountGiven_Unit = "lbs",
                AmountEaten = Taken.All
            };
            //prod 1, comp1, age2
            FlatFeedingData row2 = new FlatFeedingData
            {
                ZooId = 1,
                ZooTypeNr = 5,
                ZooAnimalId = 1,
                AnimalCode = "Tiger24",
                AnimalName = "Simba",
                BirthdayDate = new System.DateTime(2016, 11, 01),
                FeedingID = "1",
                FeddingType = FeedingType.Breakfast,
                FeedingDate = new System.DateTime(2019, 12, 01),
                Meal = "TurkeyBreast and Green Beans",
                AmountGiven = .75,
                AmountGiven_Unit = "lbs",
                AmountEaten = Taken.All
            };

            //prod 1, comp2, age 1
            FlatFeedingData row3 = new FlatFeedingData
            {
                ZooId = 1,
                ZooTypeNr = 5,
                ZooAnimalId = 1,
                AnimalCode = "Tiger24",
                AnimalName = "Simba",
                BirthdayDate = new System.DateTime(2016, 11, 01),
                FeedingID = "2",
                FeddingType = FeedingType.Breakfast,
                FeedingDate = new System.DateTime(2019, 12, 15),
                Meal = "TurkeyBreast and Green Beans",
                AmountGiven = .75,
                AmountGiven_Unit = "lbs",
                AmountEaten = Taken.All
            };
            //prod 1, comp2, age2
            FlatFeedingData row4 = new FlatFeedingData
            {
                ZooId = 1,
                ZooTypeNr = 5,
                ZooAnimalId = 1,
                AnimalCode = "Tiger24",
                AnimalName = "Simba",
                BirthdayDate = new System.DateTime(2016, 11, 01),
                FeedingID = "2",
                FeddingType = FeedingType.Breakfast,
                FeedingDate = new System.DateTime(2019, 12, 15),
                Meal = "TurkeyBreast and Green Beans",
                AmountGiven = .75,
                AmountGiven_Unit = "lbs",
                AmountEaten = Taken.All
            };
            //prod 2, comp 1, age 1
            FlatFeedingData row5 = new FlatFeedingData
            {
                ZooId = 1,
                ZooTypeNr = 5,
                ZooAnimalId = 2,
                AnimalCode = "Alli567",
                AnimalName = "Alligator Sally",
                BirthdayDate = new System.DateTime(2016, 12, 01),
                FeedingID = "1",
                FeddingType = FeedingType.Breakfast,
                FeedingDate = new System.DateTime(2019, 12, 15),
                Meal = "TurkeyBreast and Green Beans",
                AmountGiven = .75,
                AmountGiven_Unit = "lbs",
                AmountEaten = Taken.All
            };
            //prod2, comp1, age2
            FlatFeedingData row6 = new FlatFeedingData
            {
                ZooId = 1,
                ZooTypeNr = 5,
                ZooAnimalId = 2,
                AnimalCode = "Alli567",
                AnimalName = "Alligator Sally",
                BirthdayDate = new System.DateTime(2016, 12, 01),
                FeedingID = "1",
                FeddingType = FeedingType.Breakfast,
                FeedingDate = new System.DateTime(2019, 12, 15),
                Meal = "TurkeyBreast and Green Beans",
                AmountGiven = .75,
                AmountGiven_Unit = "lbs",
                AmountEaten = Taken.All
            };
            //prod2, comp2, age1
            FlatFeedingData row7 = new FlatFeedingData
            {
                ZooId = 1,
                ZooTypeNr = 5,
                ZooAnimalId = 2,
                AnimalCode = "Alli567",
                AnimalName = "Alligator Sally",
                BirthdayDate = new System.DateTime(2016, 12, 01),
                FeedingID = "2",
                FeddingType = FeedingType.Breakfast,
                FeedingDate = new System.DateTime(2019, 12, 15),
                Meal = "TurkeyBreast and Green Beans",
                AmountGiven = .75,
                AmountGiven_Unit = "lbs",
                AmountEaten = Taken.All
            };
            //prod2, comp2, age2
            FlatFeedingData row8 = new FlatFeedingData
            {
                ZooId = 1,
                ZooTypeNr = 5,
                ZooAnimalId = 2,
                AnimalCode = "Alli567",
                AnimalName = "Alligator Sally",
                BirthdayDate = new System.DateTime(2016, 12, 01),
                FeedingID = "2",
                FeddingType = FeedingType.Breakfast,
                FeedingDate = new System.DateTime(2019, 12, 15),
                Meal = "TurkeyBreast and Green Beans",
                AmountGiven = .75,
                AmountGiven_Unit = "lbs",
                AmountEaten = Taken.All
            };

            List<FlatFeedingData> data = new List<FlatFeedingData>
            {
                row1, row2, row3, row4, row5, row6, row7, row8
            };
            #endregion Arrange

            //act
            GetFeedingHistory business = new GetFeedingHistory();
            List<Zoo> result = business.BuildFeedingHistory(data, "12345678");

            #region Assert
            Assert.AreEqual(1, result[0].ZooId);
            Assert.AreEqual(5, result[0].ZooTypeNr);

            Assert.AreEqual(2, result[0].AnimalList.Count);
            Assert.AreEqual(1, result[0].AnimalList[0].ZooAnimalId);
            Assert.AreEqual(2, result[0].AnimalList[1].ZooAnimalId);
            
            Assert.AreEqual("Tiger24", result[0].AnimalList[0].AnimalCode);
            Assert.AreEqual("Simba", result[0].AnimalList[0].AnimalName);
            Assert.AreEqual(new System.DateTime(2016, 11, 01), result[0].AnimalList[0].BirthdayDate);
            
            Assert.AreEqual("Alli567", result[0].AnimalList[1].AnimalCode);
            Assert.AreEqual("Alligator Sally", result[0].AnimalList[1].AnimalName);
            Assert.AreEqual(new System.DateTime(2016, 12, 01), result[0].AnimalList[1].BirthdayDate);
         
            Assert.AreEqual(2, result[0].AnimalList[0].Feedings.Count);
            Assert.AreEqual(2, result[0].AnimalList[0].Feedings[0].FeedingHistoryList.Count);
            Assert.AreEqual("1", result[0].AnimalList[0].Feedings[0].FeedingID);
            Assert.AreEqual("TurkeyBreast and Green Beans", result[0].AnimalList[0].Feedings[0].FeedingHistoryList[0].Meal);
            Assert.AreEqual("lbs", result[0].AnimalList[0].Feedings[0].FeedingHistoryList[0].AmountGiven_Unit);
         
            Assert.AreEqual("1", result[0].AnimalList[0].Feedings[0].FeedingID);
            Assert.AreEqual("TurkeyBreast and Green Beans", result[0].AnimalList[0].Feedings[0].FeedingHistoryList[1].Meal);
            Assert.AreEqual("lbs", result[0].AnimalList[0].Feedings[0].FeedingHistoryList[1].AmountGiven_Unit);
          
            Assert.AreEqual(2, result[0].AnimalList[0].Feedings[1].FeedingHistoryList.Count);
            Assert.AreEqual("2", result[0].AnimalList[0].Feedings[1].FeedingID);
            Assert.AreEqual("TurkeyBreast and Green Beans", result[0].AnimalList[0].Feedings[1].FeedingHistoryList[0].Meal);
            Assert.AreEqual("lbs", result[0].AnimalList[0].Feedings[1].FeedingHistoryList[0].AmountGiven_Unit);
            
            Assert.AreEqual("2", result[0].AnimalList[0].Feedings[1].FeedingID);
            Assert.AreEqual("TurkeyBreast and Green Beans", result[0].AnimalList[0].Feedings[1].FeedingHistoryList[1].Meal);
            Assert.AreEqual("lbs", result[0].AnimalList[0].Feedings[1].FeedingHistoryList[1].AmountGiven_Unit);
          
            Assert.AreEqual(2, result[0].AnimalList[1].Feedings.Count);
            Assert.AreEqual(2, result[0].AnimalList[1].Feedings[0].FeedingHistoryList.Count);
            Assert.AreEqual("1", result[0].AnimalList[1].Feedings[0].FeedingID);
            Assert.AreEqual("TurkeyBreast and Green Beans", result[0].AnimalList[1].Feedings[0].FeedingHistoryList[0].Meal);
            Assert.AreEqual("lbs", result[0].AnimalList[1].Feedings[0].FeedingHistoryList[0].AmountGiven_Unit);
        
            Assert.AreEqual("1", result[0].AnimalList[1].Feedings[0].FeedingID);
            Assert.AreEqual("TurkeyBreast and Green Beans", result[0].AnimalList[1].Feedings[0].FeedingHistoryList[1].Meal);
            Assert.AreEqual("lbs", result[0].AnimalList[1].Feedings[0].FeedingHistoryList[1].AmountGiven_Unit);
           
            Assert.AreEqual(2, result[0].AnimalList[1].Feedings[1].FeedingHistoryList.Count);
            Assert.AreEqual("2", result[0].AnimalList[1].Feedings[1].FeedingID);
            Assert.AreEqual("TurkeyBreast and Green Beans", result[0].AnimalList[1].Feedings[1].FeedingHistoryList[0].Meal);
            Assert.AreEqual("lbs", result[0].AnimalList[1].Feedings[1].FeedingHistoryList[0].AmountGiven_Unit);
            
            Assert.AreEqual("2", result[0].AnimalList[1].Feedings[1].FeedingID);
            Assert.AreEqual("TurkeyBreast and Green Beans", result[0].AnimalList[1].Feedings[1].FeedingHistoryList[1].Meal);
            Assert.AreEqual("lbs", result[0].AnimalList[1].Feedings[1].FeedingHistoryList[1].AmountGiven_Unit);
            #endregion Assert
        }

        //check for multiple zoos
        [Test]
        public void BuildFeedingHistory_CheckMultipleSellingAgreements()
        {
            //arrange
            FlatFeedingData row1 = new FlatFeedingData
            {
                ZooId = 1,
                ZooTypeNr = 5,
                ZooAnimalId = 1,
                AnimalCode = "Tiger24",
                AnimalName = "Simba",
                BirthdayDate = new System.DateTime(2016, 11, 01),
                FeedingID = "1",
                FeddingType = FeedingType.Breakfast,
                FeedingDate = new System.DateTime(2019, 12, 15),
                Meal = "TurkeyBreast and Green Beans",
                AmountGiven = .75,
                AmountGiven_Unit = "lbs",
                AmountEaten = Taken.All
            };
            FlatFeedingData row2 = new FlatFeedingData
            {
                ZooId = 2,
                ZooTypeNr = 5,
                ZooAnimalId = 2,
                AnimalCode = "Alli567",
                AnimalName = "Alligator Sally",
                BirthdayDate = new System.DateTime(2016, 11, 01),
                FeedingID = "1",
                FeddingType = FeedingType.Breakfast,
                FeedingDate = new System.DateTime(2019, 12, 15),
                Meal = "TurkeyBreast and Green Beans",
                AmountGiven = .75,
                AmountGiven_Unit = "lbs",
                AmountEaten = Taken.All
            };
            List<FlatFeedingData> data = new List<FlatFeedingData>
            {
                row1,
                row2
            };

            //act
            GetFeedingHistory business = new GetFeedingHistory();
            List<Zoo> result = business.BuildFeedingHistory(data, "12345678");

            //assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, result[0].ZooId);
            Assert.AreEqual(2, result[1].ZooId);

        }
    }
}
