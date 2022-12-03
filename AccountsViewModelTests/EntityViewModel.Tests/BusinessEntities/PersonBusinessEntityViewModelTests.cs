using Xunit;
using Moq;
using System;
using AccountLib.Model.BusinessEntities;
using AccountsViewModel.EntityViewModels.Classes.BusinessEntities;
using AccountsViewModel.EntityViewModels.Classes;
using AccountsModelCore.Interfaces.BusinessEntities;

namespace AccountsViewModelTests.EntityViewModel.Tests.BusinessEntities
{
    public class PersonBusinessEntityViewModelTests :
        BusinessEntityViewModelTests
    {
        private readonly string teststring;
        private readonly DateTime testdate;
        private readonly IPerson person;
        private readonly PersonBusinessEntityViewModel PersonSut;
        protected override BusinessEntityViewModel BusinessEntityViewModelSut { get; set; }
        protected override EntityViewModel<BusinessEntity> Sut { get; set; }
        protected override BusinessEntity Entity { get; set; }

        public PersonBusinessEntityViewModelTests()
        {
            teststring = "I am a string";
            testdate = DateTime.Now;
            Entity = new Person();
            person = (IPerson)Entity;
            person.FirstName = Initialnamestring;

            PersonSut = new PersonBusinessEntityViewModel(
                person,
                CountryViewModelFactory.Object,
                SourceDocumentChildCollectionViewModelFactory.Object,
                BusinessEntitySourceDocumentTypeViewModelFactory.Object,
                Countryrepository.Object,
                ErrorCollection.Object
                );

            BusinessEntityViewModelSut = PersonSut;
            Sut = BusinessEntityViewModelSut;
        }

        [Fact]
        public void ShouldInheritFromBusinessEntityViewModel()
        {
            _ = Assert.IsAssignableFrom<BusinessEntityViewModel>(PersonSut);
        }

        [Fact]
        public void EntityPropertyShouldBeOfPersonType()
        {
            _ = Assert.IsAssignableFrom<IPerson>(PersonSut.Entity);
        }

        [Fact]
        public void ShoudHaveAPropertyThatGetsTheFirstNameFromTheUnderlyingObject()
        {
            PersonSut.FirstName = teststring;
            Assert.Equal(teststring, PersonSut.FirstName);
        }

        [Fact]
        public void ShouldHaveAPropertyThatSetsTheUnderlyingFirstNameProperty()
        {
            PersonSut.FirstName = teststring;
            Assert.Equal(teststring, person.FirstName);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventWhenFirstNamePropertySet()
        {
            Assert.PropertyChanged(PersonSut, "FirstName", () => { PersonSut.FirstName = It.IsAny<string>(); });
        }

        [Fact]
        public void ShoudHaveAPropertyThatGetsTheLastNameFromTheUnderlyingObject()
        {
            person.LastName = teststring;
            Assert.Equal(teststring, PersonSut.LastName);
        }

        [Fact]
        public void ShouldHaveAPropertyThatSetsTheUnderlyingLastNameProperty()
        {
            PersonSut.LastName = teststring;
            Assert.Equal(teststring, person.LastName);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventWhenLastNamePropertySet()
        {
            Assert.PropertyChanged(PersonSut, "LastName", () => { PersonSut.LastName = It.IsAny<string>(); });
        }

        [Fact]
        public void ShoudHaveAPropertyThatGetsTheDateOfBirthFromTheUnderlyingObject()
        {
            person.DateOfBirth = testdate;
            Assert.Equal(testdate, PersonSut.DateOfBirth);
        }

        [Fact]
        public void ShouldHaveAPropertyThatSetsTheUnderlyingDateOfBirthProperty()
        {
            PersonSut.DateOfBirth = testdate;
            Assert.Equal(testdate, person.DateOfBirth);
        }

        [Fact]
        public void ShouldRaisePropertyChangedEventWhenDateOfBirthPropertySet()
        {
            var newtime = DateTime.Now.AddDays(-2.3);
            Assert.PropertyChanged(PersonSut, "DateOfBirth", () => { PersonSut.DateOfBirth = newtime; });
        }
    }

}
