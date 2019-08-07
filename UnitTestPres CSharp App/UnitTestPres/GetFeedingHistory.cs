using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestPres
{
    public class GetFeedingHistory
    {
        private DatabaseConnect db = new DatabaseConnect();
        public List<Zoo> GetData(string animalName)
        {
            IEnumerable<FlatFeedingData> data = db.GetFeedingData(animalName);
            return BuildFeedingHistory(data, animalName);
        }

        public List<Zoo> BuildFeedingHistory(IEnumerable<FlatFeedingData> data, string animalName)
        {
            List<Zoo> zooFeedings = new List<Zoo>();

            foreach (FlatFeedingData row in data)
            {
                if (!zooFeedings.Exists(x => x.ZooId == row.ZooId))
                {
                    IEnumerable<FlatFeedingData> result = data.Where(x => x.ZooId == row.ZooId);

                    Zoo zoo = new Zoo
                    {
                        ZooId = row.ZooId,
                        ZooTypeNr = row.ZooTypeNr,
                        AnimalList = BuildAnimalList(result)
                    };
                    zooFeedings.Add(zoo);
                }
            }
            return zooFeedings;
        }

        public List<Animal> BuildAnimalList(IEnumerable<FlatFeedingData> data)
        {
            List<Animal> animals = new List<Animal>();
            foreach (FlatFeedingData row in data)
            {
                if (!animals.Exists(x => x.ZooAnimalId == row.ZooAnimalId))
                {
                    IEnumerable<FlatFeedingData> result = data.Where(x => x.ZooAnimalId == row.ZooAnimalId);

                    Animal animal = new Animal
                    {
                        ZooAnimalId = row.ZooAnimalId,
                        AnimalCode = row.AnimalCode,
                        AnimalName = row.AnimalName,
                        BirthdayDate = row.BirthdayDate,
                        Feedings = BuildFeedingsList(result, row.ZooAnimalId)
                    };
                    animals.Add(animal);
                }
            }

            return animals;
        }

        public List<Feeding> BuildFeedingsList(IEnumerable<FlatFeedingData> data, int? zooAnimalId)
        {
            List<Feeding> feedingList = new List<Feeding>();
            foreach (FlatFeedingData row in data)
            {
                if (!feedingList.Exists(x => x.FeedingID == row.FeedingID))
                {
                    IEnumerable<FlatFeedingData> result = data.Where(x => x.FeedingID == row.FeedingID && x.ZooAnimalId == zooAnimalId);

                    Feeding compOption = new Feeding
                    {
                        FeedingID = row.FeedingID,
                        Type = row.FeddingType,
                        FeedingHistoryList = BuildFeedingDetailsList(result)
                    };
                    feedingList.Add(compOption);
                }
            }
            return feedingList;
        }

        public List<FeedingDetails> BuildFeedingDetailsList(IEnumerable<FlatFeedingData> data)
        {
            List<FeedingDetails> feedingDetailsList = new List<FeedingDetails>();

            foreach (FlatFeedingData row in data)
            {
                FeedingDetails details = new FeedingDetails
                {
                    Date = row.FeedingDate,
                    Meal = row.Meal,
                    AmountGiven = row.AmountGiven,
                    AmountGiven_Unit = row.AmountGiven_Unit,
                    AmountEaten = row.AmountEaten
                };
                feedingDetailsList.Add(details);
            }

            return feedingDetailsList;
        }

    }


    #region 
    public class DatabaseConnect{
        public IEnumerable<FlatFeedingData> GetFeedingData(string animalID)
        {
            return new List<FlatFeedingData>();
        }
    }

    public class FlatFeedingData
    {
        public int ZooId { get; set; }
        public int ZooTypeNr { get; set; }
        public int? ZooAnimalId { get; set; }
        public string AnimalCode { get; set; }
        public string AnimalName { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string FeedingID { get; set; }
        public FeedingType FeddingType { get; set; }
        public DateTime FeedingDate { get; set; }
        public string Meal { get; set; }
        public double AmountGiven { get; set; }
        public string AmountGiven_Unit { get; set; }
        public Taken AmountEaten { get; set; }
    }

     public class Zoo
    {
        public int ZooId { get; set; }
        public int ZooTypeNr { get; set; }
        public List<Animal> AnimalList { get; set; }
    }

    public class Animal
    {
        public int? ZooAnimalId { get; set; }
        public string AnimalCode { get; set; }
        public string AnimalName { get; set; }
        public DateTime BirthdayDate { get; set; }
        public List<Feeding> Feedings { get; set; }

    }

    public class Feeding
    {
        public string FeedingID { get; set; }
        public FeedingType Type { get; set; }
        public List<FeedingDetails> FeedingHistoryList { get; set; }

    }

    public class FeedingDetails
    {
        public DateTime Date { get; set; }
        public string Meal { get; set; }
        public double AmountGiven { get; set; }
        public string AmountGiven_Unit { get; set; }
        public Taken AmountEaten { get; set;  }
    }

    public enum Taken {  All, Some, None }
    public enum FeedingType {  Breakfast, Lunch, Dinner, SnackAM, SnackPM }


    #endregion
}
