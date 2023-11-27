using StocksApp.DTO;
using StocksApp.Services;

namespace StockTests
{
    public class StocksServiceTests
    {
        private readonly IStockService _stockService;
        public StocksServiceTests()
        {
            _stockService = new StockServices(); ;
        }

        #region Create Purchase Order
        [Fact]
        public void CreateBuyOrder_NullRequest()
        {
            // Arrange 
            BuyOrderRequest? request = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                BuyOrderResponse buyOrderResponse = _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public void CreateBuyOrder_InvalidQuantityMin()
        {
            // Arrange 
            BuyOrderRequest? request = new BuyOrderRequest()
            {
                OrderDateTime = DateTime.Parse("2016-01-01"),
                Price=756,
                Quantity=0,
                StockName = "Microsoft",
                StockSymbol = "MSFT"
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                BuyOrderResponse buyOrderResponse = _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public void CreateBuyOrder_InvalidQuantityMax()
        {
            // Arrange 
            BuyOrderRequest? request = new BuyOrderRequest()
            {
                OrderDateTime = DateTime.Parse("2016-01-01"),
                Price = 756,
                Quantity = 100006,
                StockName = "Microsoft",
                StockSymbol = "MSFT"
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                BuyOrderResponse buyOrderResponse = _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public void CreateBuyOrder_InvalidPriceMin()
        {
            // Arrange 
            BuyOrderRequest? request = new BuyOrderRequest()
            {
                OrderDateTime = DateTime.Parse("2016-01-01"),
                Price = 0,
                Quantity = 58,
                StockName = "Microsoft",
                StockSymbol = "MSFT"
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                BuyOrderResponse buyOrderResponse = _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public void CreateBuyOrder_InvalidPriceMax()
        {
            // Arrange 
            BuyOrderRequest? request = new BuyOrderRequest()
            {
                OrderDateTime = DateTime.Parse("2016-01-01"),
                Price = 100006,
                Quantity = 58,
                StockName = "Microsoft",
                StockSymbol = "MSFT"
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                BuyOrderResponse buyOrderResponse = _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public void CreateBuyOrder_NullStockSymbol()
        {
            // Arrange 
            BuyOrderRequest? request = new BuyOrderRequest()
            {
                OrderDateTime = DateTime.Parse("2016-01-01"),
                Price = 10,
                Quantity = 58,
                StockName = "Microsoft",
                StockSymbol = null
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                BuyOrderResponse buyOrderResponse = _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public void CreateBuyOrder_InvalidOrderDateMin()
        {
            // Arrange 
            BuyOrderRequest? request = new BuyOrderRequest()
            {
                OrderDateTime = DateTime.Parse("1995-01-01"),
                Price = 10,
                Quantity = 58,
                StockName = "Microsoft",
                StockSymbol = "MSFT"
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                BuyOrderResponse buyOrderResponse = _stockService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public async void CreateBuyOrder_ValidDetails()
        {
            // Arrange 
            BuyOrderRequest? request = new BuyOrderRequest()
            {
                OrderDateTime = DateTime.Parse("2016-01-01"),
                Price = 10,
                Quantity = 58,
                StockName = "Microsoft",
                StockSymbol = "MSFT"
            };

            // Act
            BuyOrderResponse buyOrderResponse = _stockService.CreateBuyOrder(request);
            List<BuyOrderResponse> buyOrderList_from_get = _stockService.GetBuyOrders();
            BuyOrderResponse? buyOrderResponse_from_get = buyOrderList_from_get.FirstOrDefault(x => x.BuyOrderId==buyOrderResponse.BuyOrderId);
            
            // Assert
            Assert.Equal(buyOrderResponse_from_get, buyOrderResponse);
        }
        #endregion

        #region Create Sales Order
        [Fact]
        public void CreateSalesOrder_NullRequest()
        {
            // Arrange 
            SellOrderRequest? request = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                SellOrderResponse sellOrderResponse = _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public void CreateSalesOrder_InvalidQuantiyMin()
        {
            // Arrange 
            SellOrderRequest? request = new SellOrderRequest()
            {
                StockName = "Microsoft",
                OrderDateTime = DateTime.Parse("2012/01/01"),
                StockSymbol = "MSFT",
                Price = 10,
                Quantity=0
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                SellOrderResponse sellOrderResponse = _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public void CreateSalesOrder_InvalidQuantiyMax()
        {
            // Arrange 
            SellOrderRequest? request = new SellOrderRequest()
            {
                StockName = "Microsoft",
                OrderDateTime = DateTime.Parse("2012/01/01"),
                StockSymbol = "MSFT",
                Price = 10,
                Quantity = 100006
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                SellOrderResponse sellOrderResponse = _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public void CreateSalesOrder_InvalidPriceMin()
        {
            // Arrange 
            SellOrderRequest? request = new SellOrderRequest()
            {
                StockName = "Microsoft",
                OrderDateTime = DateTime.Parse("2012/01/01"),
                StockSymbol = "MSFT",
                Price = 0,
                Quantity = 40
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                SellOrderResponse sellOrderResponse = _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public void CreateSalesOrder_InvalidPriceMax()
        {
            // Arrange 
            SellOrderRequest? request = new SellOrderRequest()
            {
                StockName = "Microsoft",
                OrderDateTime = DateTime.Parse("2012/01/01"),
                StockSymbol = "MSFT",
                Price = 10007,
                Quantity = 60
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                SellOrderResponse sellOrderResponse = _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public void CreateSalesOrder_NullStockSymbol()
        {
            // Arrange 
            SellOrderRequest? request = new SellOrderRequest()
            {
                StockName = "Microsoft",
                OrderDateTime = DateTime.Parse("2012/01/01"),
                StockSymbol = null,
                Price = 10,
                Quantity = 60
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                SellOrderResponse sellOrderResponse = _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public void CreateSalesOrder_InvalidOrderDateMin()
        {
            // Arrange 
            SellOrderRequest? request = new SellOrderRequest()
            {
                StockName = "Microsoft",
                OrderDateTime = DateTime.Parse("1992/01/01"),
                StockSymbol = "MSFT",
                Price = 10,
                Quantity = 30
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                SellOrderResponse sellOrderResponse = _stockService.CreateSellOrder(request);
            });
        }

        [Fact]
        public void CreateSalesOrder_ValidDetails()
        {
            // Arrange 
            SellOrderRequest? request = new SellOrderRequest()
            {
                StockName = "Microsoft",
                OrderDateTime = DateTime.Parse("2012/01/01"),
                StockSymbol = "MSFT",
                Price = 10,
                Quantity = 50
            };

            // Act
            SellOrderResponse sellOrderResponse_add = _stockService.CreateSellOrder(request);
            SellOrderResponse? sellOrderResponse_get = _stockService.GetSellOrders().FirstOrDefault(x => x.SellOrderId==sellOrderResponse_add.SellOrderId);

            //Assert
            Assert.Equal(sellOrderResponse_add, sellOrderResponse_get); 
        }
        #endregion
    }
}