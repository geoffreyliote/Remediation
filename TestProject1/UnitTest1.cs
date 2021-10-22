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
            // création d'un singleton
            var singleton = new Remediation.Singleton();
            // test de l'instance non instanciée
            Assert.AreEqual(false, singleton.test());
            // instanciation d'une instance
            var instance = singleton.Instance;
            // test de l'existance de l'instance
            Assert.AreEqual(true, singleton.test());
            // création d'un autre singleton
            var secondSingleton = new Remediation.Singleton();
            // test de l'existance de l'instance sans l'avoir au préalable instanciée dans ce singleton
            Assert.AreEqual(true, secondSingleton.test());
        }
        [TestMethod]
        public void TestAbstractFactory()
        {
            // création d'une Factory
            IPizza pizzaDominos = new Dominos();
            // création d'un client
            PizzaClient dominosClient = new PizzaClient(pizzaDominos);
            // test si les ingrédients de la pizza Base Creme de Dominos sont bien ceux de la 4 Fromages
            Assert.AreEqual("Mozzarella, chèvre, emmental français, Fourme d’Ambert AOP" , dominosClient.GetBaseCremeIngredient());            
            // test si les ingrédients de la pizza Base Tomate de Dominos sont bien ceux de la Royale
            Assert.AreEqual("Mozzarella, Jambon, Olives, Oignon, Basilic et Champignons.", dominosClient.GetBaseTomateIngredient());

            // création d'une autre Factory
            IPizza pizzaPizzaHut = new PizzaHut();
            PizzaClient pizzaHutClient = new PizzaClient(pizzaPizzaHut);
            // test si les ingrédients de la pizza Base Creme de PizzaHut sont bien ceux de la Savoyarde
            Assert.AreEqual("Mozzarella, Lardons fumés, Pommes de terre françaises sautées, Reblochon de Savoie AOP, Origan", pizzaHutClient.GetBaseCremeIngredient());
            // test si les ingrédients de la pizza Base Tomate de Dominos sont bien ceux de la Reine
            Assert.AreEqual("Mozzarella, Jambon et Champignons.", pizzaHutClient.GetBaseTomateIngredient());
        }

        [TestMethod]
        public void TestContainer()
        {
            // création d'un objet Chambre
            Chambre chambre = new Chambre();
            // création d'un Singleton
            Remediation.Injection.Singleton singleton = new Remediation.Injection.Singleton();
            // Vérification que le Singleton n'est pas instancié
            Assert.AreEqual(null, singleton.Get());
            // Instanciation du Singleton
            singleton.Instance(chambre);
            // Vérification que le Singleton et l'objet soit bien les mêmes
            Assert.AreEqual(chambre ,singleton.Get());
            // Création d'un autre Singleton mais non Instancié
            Remediation.Injection.Singleton singleton2 = new Remediation.Injection.Singleton();
            // Vérification que le Singleton et l'objet soit bien les mêmes 
            Assert.AreEqual(chambre, singleton2.Get());

            // Création d'un Transient
            Transient transient = new Transient();

            // Instanciation du Transient
            transient.Instance(chambre);
            // Vérification que le transient renvoit bien une Chambre
            Assert.AreNotEqual(null, transient.Get());
            // Vérification que le Transient et l'objet originale ne soit pas les mêmes (car a chaque Get nouvelle objet)
            Assert.AreNotEqual(chambre, transient.Get());

            // Création d'un Scope
            Scope scope = new Scope();
            // Instanciation du Scope
            scope.Instance(chambre);
            // Vérification que le Scope renvoit bien le même objet
            Assert.AreEqual(chambre, scope.Get());
            // Création d'un autre Scope
            Scope scope2 = new Scope();
            // Vérification que le Scope ne soit pas null
            Assert.AreNotEqual(null, scope2.Get());
            // Vérification que l'objet et le Scope ne sontn pas le même objet
            Assert.AreNotEqual(chambre, scope2.Get());
            // Vérification que l'objet et le Scope ne sontn pas le même objet
            Assert.AreNotEqual(scope.Get(), scope2.Get());

        }
    }
}
