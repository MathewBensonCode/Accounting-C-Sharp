using System.Collections.Generic;
using System.Linq;
using Accounts.Repositories;
using AccountsEntityFrameworkCore;
using AccountLib.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using AccountsViewModel.Repositories;
using AccountsViewModel.Repositories.Interfaces;
using Xunit;

namespace AccountsViewModel.Xunit.Tests.Repositories.Tests
{
    abstract public class DbSetRepositoryTests<T>
        where T : class, IDbModel, new()
    {
        DbSetRepository<T> sut;
        Mock<DbSet<T>> dbSet;
	AccountsDbContext dbContext;

        public DbSetRepositoryTests()
        {
            dbSet = new Mock<DbSet<T>>();
            sut = new DbSetRepository<T>(dbContext);
	    var Options = new DbContextOptionsBuilder<AccountsDbContext>()
		    .UseInMemoryDatabase("DbSet Tests") 
		    .Options;
	    dbContext = new AccountsDbContext(Options);
        }

        [Fact]
        public void ShouldBeOfTypeIRepository()
        {
            Assert.IsAssignableFrom<IRepository<T>>(sut);
        }

        [Fact]
        public void ShouldImplementISaveRepository()
        {
            Assert.IsAssignableFrom<ISaveRepository>(sut);
        }


        [Fact]
        public void ShouldAddAnEntityToUnderlyingDbSet()
        {
            sut.AddSingle(It.IsAny<T>());
            dbSet.Verify(a => a.Add(It.IsAny<T>()), Times.Once());
        }

        [Fact]
        public void ShouldBeAbleToAddARangeOfEntitiesToUnderlyingDbSet()
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
            dbSet.Verify(a => a.Add(It.IsAny<T>()), Times.Exactly(3));
        }


        [Fact]
        public void ShouldGetAnIEnumerableOfAllEntitiesFromTheUnderlyingDbSet()
	{ 
            var t1 = new T();
            var t2 = new T();
            var t3 = new T();
            var t4 = new T();
	    var list = new List<T>(){t1, t2, t3, t4};
	    dbSet.Setup(a => a.ToList()).Returns(list);
	    Assert.Contains(t1, sut.GetAll());
	    Assert.Contains(t2, sut.GetAll());
	    Assert.Contains(t3, sut.GetAll());
	   
        }

    }
}
