using Microsoft.VisualStudio.TestTools.UnitTesting;
using Remediation;
using Remediation.Factory;
using Remediation.Injection;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSingleton()
        {
            // cr�ation d'un singleton
            var singleton = new Remediation.Singleton();
            // test de l'instance non instanci�e
            Assert.AreEqual(false, singleton.test());
            // instanciation d'une instance
            var instance = singleton.Instance;
            // test de l'existance de l'instance
            Assert.AreEqual(true, singleton.test());
            // cr�ation d'un autre singleton
            var secondSingleton = new Remediation.Singleton();
            // test de l'existance de l'instance sans l'avoir au pr�alable instanci�e dans ce singleton
            Assert.AreEqual(true, secondSingleton.test());
        }
        [TestMethod]
        public void TestAbstractFactory()
        {
            // cr�ation d'une Factory
            IPizza pizzaDominos = new Dominos();
            // cr�ation d'un client
            PizzaClient dominosClient = new PizzaClient(pizzaDominos);
            // test si les ingr�dients de la pizza Base Creme de Dominos sont bien ceux de la 4 Fromages
            Assert.AreEqual("Mozzarella, ch�vre, emmental fran�ais, Fourme d�Ambert AOP" , dominosClient.GetBaseCremeIngredient());            
            // test si les ingr�dients de la pizza Base Tomate de Dominos sont bien ceux de la Royale
            Assert.AreEqual("Mozzarella, Jambon, Olives, Oignon, Basilic et Champignons.", dominosClient.GetBaseTomateIngredient());

            // cr�ation d'une autre Factory
            IPizza pizzaPizzaHut = new PizzaHut();
            PizzaClient pizzaHutClient = new PizzaClient(pizzaPizzaHut);
            // test si les ingr�dients de la pizza Base Creme de PizzaHut sont bien ceux de la Savoyarde
            Assert.AreEqual("Mozzarella, Lardons fum�s, Pommes de terre fran�aises saut�es, Reblochon de Savoie AOP, Origan", pizzaHutClient.GetBaseCremeIngredient());
            // test si les ingr�dients de la pizza Base Tomate de Dominos sont bien ceux de la Reine
            Assert.AreEqual("Mozzarella, Jambon et Champignons.", pizzaHutClient.GetBaseTomateIngredient());
        }

        [TestMethod]
        public void TestContainer()
        {
            // cr�ation d'un objet Chambre
            Chambre chambre = new Chambre();
            // cr�ation d'un Singleton
            Remediation.Injection.Singleton singleton = new Remediation.Injection.Singleton();
            // V�rification que le Singleton n'est pas instanci�
            Assert.AreEqual(null, singleton.Get());
            // Instanciation du Singleton
            singleton.Instance(chambre);
            // V�rification que le Singleton et l'objet soit bien les m�mes
            Assert.AreEqual(chambre ,singleton.Get());
            // Cr�ation d'un autre Singleton mais non Instanci�
            Remediation.Injection.Singleton singleton2 = new Remediation.Injection.Singleton();
            // V�rification que le Singleton et l'objet soit bien les m�mes 
            Assert.AreEqual(chambre, singleton2.Get());

            // Cr�ation d'un Transient
            Transient transient = new Transient();

            // Instanciation du Transient
            transient.Instance(chambre);
            // V�rification que le transient renvoit bien une Chambre
            Assert.AreNotEqual(null, transient.Get());
            // V�rification que le Transient et l'objet originale ne soit pas les m�mes (car a chaque Get nouvelle objet)
            Assert.AreNotEqual(chambre, transient.Get());

            // Cr�ation d'un Scope
            Scope scope = new Scope();
            // Instanciation du Scope
            scope.Instance(chambre);
            // V�rification que le Scope renvoit bien le m�me objet
            Assert.AreEqual(chambre, scope.Get());
            // Cr�ation d'un autre Scope
            Scope scope2 = new Scope();
            // V�rification que le Scope ne soit pas null
            Assert.AreNotEqual(null, scope2.Get());
            // V�rification que l'objet et le Scope ne sontn pas le m�me objet
            Assert.AreNotEqual(chambre, scope2.Get());
            // V�rification que l'objet et le Scope ne sontn pas le m�me objet
            Assert.AreNotEqual(scope.Get(), scope2.Get());

        }
    }
}
