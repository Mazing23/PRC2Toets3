﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PRC2Toets2;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System;

namespace AnimalTesting
{
    [TestClass]
    public class Administration_Test
    {
        Administration admin ;
        Animal animala;
        Animal animalb;
        Animal animalc;

        [TestInitialize]
        public void Setup()
        {
            admin = new Administration();
            animala = new Cat(13, new SimpleDate(9, 8, 1995), "Harry", "");
            animalb = new Dog(14, new SimpleDate(9, 8, 1995), "Harry", new SimpleDate(9, 6, 2018));
            animalc = new Dog(15, new SimpleDate(9, 8, 1995), "Harry", new SimpleDate(9, 6, 2018));
        }

        [TestMethod]
        public void Add_WillAddAnimaltoAllAnimals_and_return_True()
        {
            bool result = admin.Add(animala);
            Assert.IsTrue(result);
            CollectionAssert.AreEquivalent(new[] { animala }, admin.AllAnimals);
        }

        [TestMethod]
        public void Add_WillNotAddDuplicateAnimal()
        {           
            admin.Add(animala);
            bool result = admin.Add(animala);
            Assert.IsFalse(result);
            CollectionAssert.AreEquivalent(new[] { animala }, admin.AllAnimals);
        }

        [TestMethod]
        public void Remove_Returns_False_WhenAnimalNotPresent_to_Remove()
        {
            bool result = admin.RemoveAnimal(13);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Remove_Returns_True_IfAnimal_is_Removed_and_RemovesAnimalFromList()
        {
            admin.Add(animala);
            bool result = admin.RemoveAnimal(animala.ChipRegistrationNumber);
            Assert.AreEqual(null, admin.FindAnimal(13));
            Assert.IsTrue(result);
            CollectionAssert.DoesNotContain(admin.AllAnimals, animala);
        }

        [TestMethod]
        public void FindAnimal_AnimalDoesExist_ReturnsAnimalWith_Chip_Number()
        {
            admin.Add(animala);
            Assert.AreEqual(admin.FindAnimal(13), animala);
        }

        [TestMethod]
        public void FindAnimal_AnimalDoesNotExist_ReturnsNullWith_Chip_Number()
        {
            admin.Add(animala);
            Assert.AreEqual(admin.FindAnimal(12), null);
        }

        [TestMethod]
        public void Add_AnimalWhillChangeNumber_and_notAllowDuplicateChipAdded()
        {
            admin.Add(animala);
            admin.Add(animalb);
            admin.Add(animalc);

            int number = 13;
            Animal animale = new Dog(number, new SimpleDate(9, 8, 2017), "Louise", new SimpleDate(7, 8, 2018));
            while (!admin.Add(animale))
            {
                number++;
                animale = new Dog(number, new SimpleDate(9, 8, 2017), "Louise", new SimpleDate(7, 8, 2018));
            }

            Assert.AreEqual(16, animale.ChipRegistrationNumber);
            Assert.AreEqual(animale, admin.FindAnimal(16));
            CollectionAssert.Contains(admin.AllAnimals, animale);
        }


        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void Administration_Save_DirectoryException()
        {
            string foldername = "C:\\Users\\Peter\\Documents\\School\\Animals.txt";
            admin.Save(foldername);
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void Administration_Save_IOException()
        {
            string foldername = "C:\\Users\\Gijs\\Documents\\School\\Animals.txt";
            admin.Save(foldername);
        }

        [TestMethod]
        [ExpectedException(typeof(SerializationException))]
        public void Administration_Save_SerializationException()
        {
            string foldername = "D:\\Users\\Gijs\\Documents\\School\\Animals.txt";
            admin.Save(foldername);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Administration_Save_ArgumentNullException()
        {
            string foldername = null;
            admin.Save(foldername);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void Administration_Load_DirectoryException()
        {
            string foldername = "C:\\Users\\Peter\\Documents\\School\\Animals.txt";
            admin.Load(foldername);
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void Administration_Load_IOException()
        {
            string foldername = "D:\\Users\\Gijs\\Documents\\School\\Animals.txt";
            admin.Load(foldername);
        }

        [TestMethod]
        [ExpectedException(typeof(SerializationException))]
        public void Administration_Load_SerializationException()
        {
            string foldername = "C:\\Users\\Gijs\\Documents\\School\\Animals.txt";
            admin.Load(foldername);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Administration_Load_ArgumentNullException()
        {
            string foldername = null;
            admin.Load(foldername);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void Administration_Export_DirectoryException()
        {
            string foldername = "C:\\Users\\Peter\\Documents\\School\\Animals.txt";
            admin.Export(foldername);
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void Administration_Export_IOException()
        {
            string foldername = "D:\\Users\\Gijs\\Documents\\School\\Animals.txt";
            admin.Export(foldername);
        }

        [TestMethod]
        [ExpectedException(typeof(SerializationException))]
        public void Administration_Export_SerializationException()
        {
            string foldername = "C:\\Users\\Gijs\\Documents\\School\\Animals.txt";
            admin.Export(foldername);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Administration_Export_ArgumentNullException()
        {
            string foldername = null;
            admin.Export(foldername);
        }
    }
}
