using System;
using System.Collections.Generic;
using AccountsModelCore.Interfaces;
using AccountsViewModel.Repositories;
using AccountsViewModel.Repositories.Interfaces;
using Moq;
using Xunit;

namespace AccountsViewModelTests.Repositories.Tests.ChildRepositories
{
    public abstract class ChildCollectionRepositoryTests<T>
        where T : class, IDbModel, new()
    {
        private readonly ChildCollectionRepository<T> sut;
        private readonly List<T> collectionList;
        private readonly ChildCollectionRepository<T> sutWithList;

        protected Mock<ICollection<T>> Collection { get; }

        public ChildCollectionRepositoryTests()
        {
            Collection = new Mock<ICollection<T>>();
            sut = new ChildCollectionRepository<T>(Collection.Object);

            collectionList = new List<T>();
            for (int i = 1; i <= 100; i++)
            {
                var t = new T
                {
                    Id = i
                };

                collectionList.Add(t);
            }

            sutWithList = new ChildCollectionRepository<T>(collectionList);
        }

        [Fact]
        public void ShouldBeOfTypeIRepository()
        {

            Assert.IsAssignableFrom<IRepository<T>>(sut);
        }

        [Fact]
        public void ShouldAddAnEntityToUnderlyingCollection()
        {
            sut.AddSingle(It.IsAny<T>());
            Collection.Verify(a => a.Add(It.IsAny<T>()), Times.Once());
        }

        [Fact]
        public void ShouldBeAbleToAddARangeOfEntitiesToUnderlyingCollection()
        {
            var enumerator = new Mock<IEnumerator<T>>();
            var samplelist = new Mock<IEnumerable<T>>();

            enumerator.Setup(a => a.Current).Returns(It.IsAny<T>());
            enumerator.SetupSequence(a => a.MoveNext())
                .Returns(true)
                .Returns(true)
                .Returns(true)
                .Returns(false);

            samplelist.Setup(a => a.GetEnumerator()).Returns(enumerator.Object);
            sut.AddRange(samplelist.Object);
            Collection.Verify(a => a.Add(It.IsAny<T>()), Times.Exactly(3));
        }

        [Fact]
        public void ShouldGetAnIEnumerableOfAllEntitiesFromTheUnderlyingCollection()
        {
            var t1 = new T();
            var t2 = new T();
            var t3 = new T();
            var t4 = new T();
            var collection1 = new List<T> { t1, t2, t3, t4 };
            var sut1 = new ChildCollectionRepository<T>(collection1);
            Assert.Contains(t1, sut1.GetAll());
            Assert.Contains(t2, sut1.GetAll());
            Assert.Contains(t3, sut1.GetAll());
            Assert.Contains(t4, sut1.GetAll());

        }

        [Fact]
        public void ShouldRemoveASingleEntityFromCollection()
        {
            var t1 = new T();
            var t2 = new T();
            var collection1 = new List<T> { t1 };
            var sut1 = new ChildCollectionRepository<T>(collection1);
            sut1.RemoveSingle(t1);
            Assert.DoesNotContain(t1, collection1);
        }

        [Fact]
        public void ShouldThrowExceptionIfDeleteAttemptedOnItemNotInCollection()
        {
            var t1 = new T();
            var t2 = new T();
            var collection1 = new List<T> { t1 };
            var sut1 = new ChildCollectionRepository<T>(collection1);
            Assert.Throws<ArgumentOutOfRangeException>(() => sut1.RemoveSingle(t2));
        }

        [Fact]
        public void ShouldRemoveARangeOfEntitiesFromCollection()
        {
            var t1 = new T();
            var t2 = new T();
            var t3 = new T();
            var t4 = new T();

            var collection1 = new List<T> { t1, t2, t3, t4 };
            var listtoremove = new List<T> { t1, t3 };

            var sut1 = new ChildCollectionRepository<T>(collection1);
            sut1.RemoveRange(listtoremove);
            Assert.DoesNotContain(t1, collection1);
            Assert.DoesNotContain(t3, collection1);
        }

        [Fact]
        public void ShouldThrowExceptionIfAnyEntityInCollectionToBeRemovedDoesNotExist()

        {
            var t1 = new T();
            var t2 = new T();
            var t3 = new T();
            var t4 = new T();

            var collection1 = new List<T> { t2, t3, t4 };
            var listtoremove = new List<T> { t1, t3 };

            var sut1 = new ChildCollectionRepository<T>(collection1);
            Assert.Throws<ArgumentOutOfRangeException>(() => sut1.RemoveRange(listtoremove));

        }

        [Fact]
        public void ShouldHaveAPropertyWithThePageSizeForTheCollection()
        {
            Assert.True(sut.GetPageSize() > 0);
        }

        [Fact]
        public void ShouldHaveAPropertyWithTheSizeOfTheCollection()
        {
            Assert.Equal(100, sutWithList.Count);
        }

        [Fact]
        public void ShouldReturnEntityWithGivenIdFromCollection()
        {
            var t1 = new T
            {
                Id = 10
            };
            Assert.Equal(t1.Id, sutWithList.Find(t1.Id).Id);
        }

        [Fact]
        public void ShouldReturnNullFromFindIfEntityNotFound()
        {
            var t1 = new T
            {
                Id = 200
            };
            Assert.Null(sutWithList.Find(t1.Id));
        }

        [Fact]
        public void ShouldGetASpecifiedPageFromTheCollection()
        {
            int pagenumber = 3;
            var resultcollection = sutWithList.GetPageCollection(pagenumber);
            var enumerate = resultcollection.GetEnumerator();
            enumerate.MoveNext();
            var current = enumerate.Current;
            Assert.Equal(21, current.Id);
        }

        [Fact]
        public void ShouldReturnADefaultViewCollection()
        {
            var resultcollection = sutWithList.GetDefault();
            var enumerator = resultcollection.GetEnumerator();
            enumerator.MoveNext();
            var current = enumerator.Current;
            Assert.Equal(1, current.Id);
        }

    }
}
