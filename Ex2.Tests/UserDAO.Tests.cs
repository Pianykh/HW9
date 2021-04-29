using NUnit.Framework;

namespace Ex2.Tests
{
    public class UserDAOTests
    {
        [Test]
        public void AddUser_ShouldAddUser()
        {            
            UserDAO.AddUser("testLogin", "testPassword");
            var expectedLogin = "testLogin";
            var expectedPassword = "testPassword";
            var user = UsersDataBase.Users[1];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedLogin, user.Login);
                Assert.AreEqual(expectedPassword, user.Password);
            });
        }

        [Test]
        public void GetUser_ShouldGetUser()
        {
            var user = UserDAO.GetUser("sys", "sys");
            var expectedLogin = "sys";
            var expectedPassword = "sys";

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedLogin, user.Login);
                Assert.AreEqual(expectedPassword, user.Password);
            });
        }

        [Test]
        public void IsUserExist_ShouldReturnTrueIfUserExist()
        {
            Assert.IsTrue(UserDAO.IsUserExist("sys"));
        }

        [Test]
        public void IsUserExist_ShouldReturnFalseIfUserDontExist()
        {
            Assert.IsFalse(UserDAO.IsUserExist("loginthatdontexist"));
        }
        
    }
}