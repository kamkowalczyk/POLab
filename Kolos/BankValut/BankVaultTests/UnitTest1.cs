using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item item;
        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            item = new Item("Kamil", "1234");
        }
        [Test]
        public void Ctor_ShouldSetCorretclyDictionary()
        {
            Assert.That(bankVault.VaultCells, Is.TypeOf<ImmutableDictionary<string, Item>>());
        }
        [Test]
        public void AddItem_ThrowsException_WhenValutDoesNotContainCells()
        {

            Assert.Throws<ArgumentException>(() => bankVault.AddItem("I2", item));
        }
        [Test]
        public void AddItem_ThrowsException_WhenCellIsAlreadyTaken()
        {
            bankVault.AddItem("A2", item);
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A2", item));
        }
        [Test]
        public void AddItem_ThrowsException_WhenItemInCellExists()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A2", item));
        }
        [Test]
        public void AddItem_MethodShouldAddItemCorrectly()
        {
            Assert.That(bankVault.AddItem("A1", item), Is.EqualTo($"Item:{item.ItemId} saved successfully!"));
        }
        [Test]
        public void RemoveItem_ThrowsException_WhenCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(()=>bankVault.RemoveItem("A1", item));
        }
        [Test]
        public void RemoveItem_ThrowsException_WhenItemDoesNotExistInTheCell()
        {
            bankVault.AddItem("A1", item);
            Item item1 = new Item("Asia","1234");
            Assert.Throws<ArgumentException>(()=>bankVault.RemoveItem("A1", item1));
        }
        [Test]
        public void RemoveItem_MethodShouldRemoveItemCorrectly()
        {
            bankVault.AddItem("A1", item);
            Assert.That(bankVault.RemoveItem("A1", item), Is.EqualTo($"Remove item:{item.ItemId} successfully!"));
        }
        [Test]
        public void When_RemoveItem_ShouldSetNull()
        {
            bankVault.AddItem("A1", item);
            bankVault.RemoveItem("A1", item);
            Assert.That(bankVault.VaultCells["A1"], Is.EqualTo(null));
        }

        [Test]
        public void When_AddItem_ShouldSetItem()
        {
            bankVault.AddItem("A1", item);
            Assert.That(bankVault.VaultCells["A1"], Is.EqualTo(item));
        }

    }
}