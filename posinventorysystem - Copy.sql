-- phpMyAdmin SQL Dump
-- version 4.8.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 11, 2020 at 10:42 AM
-- Server version: 10.1.32-MariaDB
-- PHP Version: 7.2.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `posinventorysystem`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddProduct` (`_Barcode` VARCHAR(45), `_ProductName` VARCHAR(45), `_Description` VARCHAR(45), `_PurchasePrice` DECIMAL(10,2), `_SellingPrice` DECIMAL(10,2), `_Image` BLOB)  BEGIN
INSERT INTO products(Barcode, ProductName, Description, PurchasePrice, SellingPrice, Image, Status)
VALUES (_Barcode, _ProductName, _Description, _PurchasePrice, _SellingPrice, _Image, 'Active');
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `AddProductTransaction` (`_ProductID` INT(11), `_PurchasePrice` DECIMAL(10,2), `_SoldPrice` DECIMAL(10,2), `_Quantity` INT(11))  BEGIN
INSERT INTO product_transaction(TransactionID, ProductID, PurchasePrice, SoldPrice, Quantity)
VALUES((SELECT TransactionID FROM transactions ORDER BY TransactionID DESC LIMIT 1), _ProductID, _PurchasePrice, _SoldPrice, _Quantity);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `AddStocks` (`_ProductID` INT(11), `_Quantity` INT(11), `_DateAdded` DATETIME, `_ExpirationDate` DATETIME, `_Status` VARCHAR(45))  BEGIN
INSERT INTO stocks(ProductID, Quantity, DateAdded, ExpirationDate, Status)
VALUES(_ProductID, _Quantity, _DateAdded, _ExpirationDate, _Status);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `AddTransactionData` (`_Username` VARCHAR(45), `_TotalAmount` DECIMAL(10,2), `_AmounTendered` DECIMAL(10,2), `_TotalChange` DECIMAL(10,2), `_Vat` DECIMAL(10,2), `_Discount` DECIMAL(10,2), `_UserDiscounted` VARCHAR(45), `_Date` DATETIME)  BEGIN
INSERT INTO transactions(Username, TotalAmount, AmountTendered, TotalChange, Vat, Discount, UserDiscounted, Date)
VALUES(_Username, _TotalAmount, _AmounTendered, _TotalChange, _Vat, _Discount, _UserDiscounted, _Date);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `AddUsersAccount` (`_UsersType` VARCHAR(45), `_Username` VARCHAR(45), `_Password` VARCHAR(45), `_Status` VARCHAR(45))  BEGIN
INSERT INTO users(UsersType, Username, Password, Status)
VALUES(_UsersType, _Username, _Password, _Status);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `AddUsersPersonalInfo` (`_FirstName` VARCHAR(60), `_LastName` VARCHAR(60), `_MiddleName` VARCHAR(60), `_BirthDay` VARCHAR(60), `_Age` INT(11), `_Address` VARCHAR(100), `_Contact` VARCHAR(15), `_Sex` VARCHAR(45), `_Image` BLOB)  BEGIN
INSERT INTO users_information(UsersID, FirstName, LastName, MiddleName, BirthDay, Age, Address, Contact, Sex, Image)
VALUES (LAST_INSERT_ID(), _FirstName, _LastName, _MiddleName, _BirthDay, _Age, _Address, _Contact, _Sex, _Image);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteAllProductsLog` ()  BEGIN
DELETE
FROM products_log;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteAllTotalStocks` ()  BEGIN
DELETE
FROM
stockstotal_log;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteAllUsersInformationLog` ()  BEGIN
DELETE
FROM usersinformation_log;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteAllUsersLog` ()  BEGIN
DELETE
FROM users_log;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteIndividualStocksLog` (`_StocksLogID` INT(11))  BEGIN
DELETE
FROM stocksindividual_log
WHERE StocksLogID = _StocksLogID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteIndividualStocksLogBydID` (`_StocksLogID` INT(11))  BEGIN
DELETE
FROM stocksindividual_log
WHERE StocksLogID = _StocksLogID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteProduct` (`_ProductID` INT(11))  BEGIN
DELETE FROM products
WHERE ProductID = _ProductID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteProductsLogByID` (`_ProductsLogID` INT(11))  BEGIN
DELETE
FROM products_log
WHERE ProductsLogID = _ProductsLogID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteStocksByID` (`_StocksID` INT(11))  BEGIN
DELETE
FROM stocks
WHERE StocksID = _StocksID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteStocksEmptyByDate` ()  BEGIN
DELETE
FROM stocks
WHERE DATE_ADD(ExpirationDate, INTERVAL 90 DAY) = NOW();	
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteStocksQtyEmptyByID` (`_StocksID` INT(11))  BEGIN
DELETE
FROM stocks
WHERE StocksID = _StocksID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteTotalStocksByID` (`_ProductID` INT(11))  BEGIN
DELETE s.*
FROM stocks s
INNER JOIN products p
ON s.ProductID = p.ProductID
WHERE s.ProductID = _ProductID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteTotalStocksLog` ()  BEGIN
DELETE
FROM stocksindividual_log;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteTotalStocksLogBydID` (`_StocksTotalLogID` INT(11))  BEGIN
DELETE
FROM stockstotal_log
WHERE StocksTotalLogID = _StocksTotalLogID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteUsersAccount` (`_UsersID` INT(11))  BEGIN
DELETE u.*, ui.*
FROM users u
INNER JOIN users_information ui
ON u.UsersID = ui.UsersID
WHERE u.UsersID = _UsersID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteUsersInformationLogByID` (`_UsersInformationID` INT(11))  BEGIN
DELETE
FROM usersinformation_log
WHERE UsersInformationID = _UsersInformationID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteUsersLogByID` (`_UsersLogID` INT(11))  BEGIN
DELETE
FROM users_log
WHERE UsersLogID = _UsersLogID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `GetUsersAccountNInformationByID` (`_UsersID` INT(11))  BEGIN
SELECT *
FROM users
INNER JOIN users_information
ON users.UsersID = users_information.UsersID
WHERE users.UsersID = _UsersID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertIndividualStocksLog` (`_UsersID` INT(11), `_UsersName` VARCHAR(45), `_StocksID` INT(11), `_ProductID` INT(11), `_ProductName` VARCHAR(45), `_DateAndTime` DATETIME, `_Action` VARCHAR(45))  BEGIN
INSERT INTO stocksindividual_log(UsersID, UsersName, StocksID, ProductID,  ProductName, DateAndTime, Action)
VALUES (_UsersID, _UsersName, _StocksID, _ProductID, _ProductName, _DateAndTime, _Action);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertProductLog` (`_UsersID` INT(11), `_UsersName` VARCHAR(45), `_ProductID` INT(11), `_ProductName` VARCHAR(25), `_DateAndTime` DATETIME, `_Action` VARCHAR(25))  BEGIN
INSERT INTO products_log(UsersID, UsersName, ProductID, ProductName, DateAndTime, Action)
VALUES(_UsersID, _UsersName, _ProductID, _ProductName, _DateAndTime, _Action);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertTotalStocksLog` (`_UsersID` INT(11), `_UsersName` VARCHAR(45), `_ProductID` INT(11), `_ProductName` VARCHAR(45), `_DateAndTime` DATETIME, `_Action` VARCHAR(45))  BEGIN
INSERT INTO stockstotal_log(UsersID, UsersName, ProductID, ProductName, DateAndtime, Action)
VALUES(_UsersID, _UsersName, _ProductID, _ProductName, _DateAndTime, _Action);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertUserLog` (`_UserID` INT(11), `_UserName` VARCHAR(45), `_TimeIn` DATETIME, `_TimeOut` DATETIME)  BEGIN
INSERT INTO users_log(UserID, TimeIn, TimeOut, UserName)
VALUES(_UserID, _TimeIn, _TimeOut, _UserName);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertUsersinformationLog` (`_UsersID` INT(11), `_UsersName` VARCHAR(45), `_UsersSubjectID` INT(11), `_UsersSubjectName` VARCHAR(25), `_DateAndTime` DATETIME, `_Action` VARCHAR(25))  BEGIN
INSERT INTO usersinformation_log(UsersID, UsersName, UsersSubjectID, UsersSubjectName, DateAndTime, Action)
VALUES(_UsersID, _UsersName, _UsersSubjectID, _UsersSubjectName, _DateAndTime, _Action);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SearchUsers` (`_Username` VARCHAR(45), `_Password` VARCHAR(45))  BEGIN
SELECT *
FROM users
WHERE Username = _Username && Password = _Password;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SearchUsersInfoByUsersID` (`_UsersID` VARCHAR(45))  BEGIN
SELECT *
FROM users_information
WHERE UsersID = _UsersID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectAdminPassword` (`_Password` VARCHAR(45))  BEGIN
SELECT *
FROM users
WHERE Password = _Password && UsersType = 'Admin';
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectAdminPasswordByID` (`_UsersID` INT(11), `_Password` VARCHAR(45))  BEGIN
SELECT *
FROM users
WHERE UsersID = _UsersID && Password = _Password;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectAdminPasswordByIDForDiscount` (`_Password` VARCHAR(45))  BEGIN
SELECT *
FROM users u 
INNER JOIN users_information ui
ON u.UsersID = ui.UsersID
WHERE u.Password = _Password && u.UsersType = 'Admin';
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectCurrentProductQuantity` (`_BarCode` VARCHAR(45), `_Price` DECIMAL(10,2))  BEGIN

SELECT sum(s.Quantity) as Quantity
FROM products p
INNER JOIN stocks s
ON p.ProductID = s.ProductID
WHERE p.Barcode = _Barcode && FORMAT(p.SellingPrice, 2) = _Price;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectIfProductBarcodeExist` (`_BarCode` VARCHAR(45))  BEGIN
SELECT ProductID 
FROM products
WHERE BarCode = _BarCode;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectIfProductBarcodeExistOnUpdate` (`_ProductID` INT(11), `_BarCode` VARCHAR(45))  BEGIN
SELECT ProductID 
FROM products
WHERE BarCode = _BarCode AND ProductID != _ProductID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductByBarCode` (`_BarCode` VARCHAR(45))  BEGIN

SELECT p.ProductID, p.BarCode, p.ProductName, FORMAT(p.SellingPrice, 2) as Price, sum(s.Quantity) as Quantity
FROM products p
INNER JOIN stocks s
ON p.ProductID = s.ProductID
WHERE Barcode = _Barcode && p.Status = 'Active'
GROUP BY p.ProductID;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductByID` (`_ProductID` INT(11))  BEGIN
SELECT *
FROM products
WHERE ProductID = _ProductID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductImageByCodeNPrice` (`_BarCode` VARCHAR(25), `_Price` DECIMAL(10,2))  BEGIN
SELECT *
FROM products
WHERE BarCode =_BarCode && FORMAT(SellingPrice, 2) = _Price;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductLastInsertedID` ()  BEGIN
SELECT ProductID
FROM products
ORDER BY ProductID DESC LIMIT 1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductPictureByID` (`_ProductID` INT(11))  BEGIN
SELECT Image
FROM products
WHERE ProductID = _ProductID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductPurchasePriceById` (`_ProductID` INT(11))  BEGIN
SELECT PurchasePrice
FROM products
WHERE ProductID = _ProductID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductsActiveForView` ()  BEGIN

SELECT ProductID, BarCode, ProductName, Description, FORMAT(PurchasePrice, 2) AS PurchasePrice, FORMAT(SellingPrice, 2) AS SellingPrice
FROM products
WHERE Status = "Active";

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductsForView` ()  BEGIN
SELECT *
FROM products
WHERE Status = "Active";
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductsLogsForView` ()  BEGIN
SELECT ProductsLogID, UsersID, UsersName, ProductID, ProductName,  DATE_FORMAT(DateAndTime, "%m-%d-%Y %h:%i %p") AS Date_and_Time, Action
FROM products_log;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductsNotActiveForView` ()  BEGIN

SELECT ProductID, BarCode, ProductName, Description, FORMAT(PurchasePrice, 2) AS PurchasePrice, FORMAT(SellingPrice, 2) AS SellingPrice
FROM products
WHERE Status = "Not Active";

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductsTransactionAnually` ()  BEGIN

SELECT p.ProductID, p.ProductName, FORMAT(pt.PurchasePrice, 2) AS PurchasePrice, FORMAT(pt.SoldPrice, 2) AS SoldPrice, SUM(pt.Quantity) as Quantity,
FORMAT((pt.SoldPrice * SUM(pt.Quantity)), 2) as TotalPrice,
FORMAT(((pt.SoldPrice * SUM(pt.Quantity)) - (pt.PurchasePrice * SUM(pt.Quantity))), 2) as TotalSales
FROM products p
INNER JOIN product_transaction pt
ON p.ProductID = pt.ProductID
INNER JOIN transactions t
ON pt.TransactionID = t.TransactionID
WHERE DATE_FORMAT(t.Date, "%Y") = DATE_FORMAT(Now(), "%Y")
GROUP BY pt.ProductID, pt.SoldPrice, pt.PurchasePrice; 

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductsTransactionByDate` (`_DateFrom` DATETIME, `_DateTo` DATETIME)  BEGIN

SELECT p.ProductID, p.ProductName, FORMAT(pt.PurchasePrice, 2) AS PurchasePrice, FORMAT(pt.SoldPrice, 2) AS SoldPrice, SUM(pt.Quantity) as Quantity,
FORMAT((pt.SoldPrice * SUM(pt.Quantity)), 2) as TotalPrice,
FORMAT(((pt.SoldPrice * SUM(pt.Quantity)) - (pt.PurchasePrice * SUM(pt.Quantity))), 2) as TotalSales
FROM products p
INNER JOIN product_transaction pt
ON p.ProductID = pt.ProductID
INNER JOIN transactions t
ON pt.TransactionID = t.TransactionID
WHERE DATE_FORMAT(t.Date, "%Y %m %d") BETWEEN DATE_FORMAT(_DateFrom, "%Y %m %d") AND DATE_FORMAT(_DateTo, "%Y %m %d")
GROUP BY pt.ProductID, pt.SoldPrice, pt.PurchasePrice; 

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductsTransactionByOneDate` (`_DateToAndFrom` DATETIME)  BEGIN

SELECT p.ProductID, p.ProductName, FORMAT(pt.PurchasePrice, 2) AS PurchasePrice, FORMAT(pt.SoldPrice, 2) AS SoldPrice, SUM(pt.Quantity) as Quantity,
FORMAT((pt.SoldPrice * SUM(pt.Quantity)), 2) as TotalPrice,
FORMAT(((pt.SoldPrice * SUM(pt.Quantity)) - (pt.PurchasePrice * SUM(pt.Quantity))), 2) as TotalSales
FROM products p
INNER JOIN product_transaction pt
ON p.ProductID = pt.ProductID
INNER JOIN transactions t
ON pt.TransactionID = t.TransactionID
WHERE DATE_FORMAT(t.Date, "%Y %m %d") = DATE_FORMAT(_DateToAndFrom, "%Y %m %d")
GROUP BY pt.ProductID, pt.SoldPrice, pt.PurchasePrice; 

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductsTransactionDaily` ()  BEGIN

SELECT p.ProductID, p.ProductName, FORMAT(pt.PurchasePrice, 2) AS PurchasePrice, FORMAT(pt.SoldPrice, 2) AS SoldPrice, SUM(pt.Quantity) as Quantity,
FORMAT((pt.SoldPrice * SUM(pt.Quantity)), 2) as TotalPrice,
FORMAT(((pt.SoldPrice * SUM(pt.Quantity)) - (pt.PurchasePrice * SUM(pt.Quantity))), 2) as TotalSales
FROM products p
INNER JOIN product_transaction pt
ON p.ProductID = pt.ProductID
INNER JOIN transactions t
ON pt.TransactionID = t.TransactionID
WHERE DATE_FORMAT(t.Date, "%d") = DATE_FORMAT(Now(), "%d") AND DATE_FORMAT(t.Date, "%Y") = DATE_FORMAT(Now(), "%Y")
GROUP BY pt.ProductID, pt.SoldPrice, pt.PurchasePrice; 


END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductsTransactionMonthly` ()  BEGIN

SELECT p.ProductID, p.ProductName, FORMAT(pt.PurchasePrice, 2) AS PurchasePrice, FORMAT(pt.SoldPrice, 2) AS SoldPrice, SUM(pt.Quantity) as Quantity,
FORMAT((pt.SoldPrice * SUM(pt.Quantity)), 2) as TotalPrice,
FORMAT(((pt.SoldPrice * SUM(pt.Quantity)) - (pt.PurchasePrice * SUM(pt.Quantity))), 2) as TotalSales
FROM products p
INNER JOIN product_transaction pt
ON p.ProductID = pt.ProductID
INNER JOIN transactions t
ON pt.TransactionID = t.TransactionID
WHERE DATE_FORMAT(t.Date, "%m") = DATE_FORMAT(Now(), "%m") AND DATE_FORMAT(t.Date, "%Y") = DATE_FORMAT(Now(), "%Y")
GROUP BY pt.ProductID, pt.SoldPrice, pt.PurchasePrice; 

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectProductsTransactionWeekly` ()  BEGIN

SELECT p.ProductID, p.ProductName, FORMAT(pt.PurchasePrice, 2) AS PurchasePrice, FORMAT(pt.SoldPrice, 2) AS SoldPrice, SUM(pt.Quantity) as Quantity,
FORMAT((pt.SoldPrice * SUM(pt.Quantity)), 2) as TotalPrice,
FORMAT(((pt.SoldPrice * SUM(pt.Quantity)) - (pt.PurchasePrice * SUM(pt.Quantity))), 2) as TotalSales
FROM products p
INNER JOIN product_transaction pt
ON p.ProductID = pt.ProductID
INNER JOIN transactions t
ON pt.TransactionID = t.TransactionID
WHERE week(t.Date) = week(Now()) AND DATE_FORMAT(t.Date, "%Y") = DATE_FORMAT(Now(), "%Y")
GROUP BY pt.ProductID, pt.SoldPrice, pt.PurchasePrice; 

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectStocksByBarcode` (`_Barcode` VARCHAR(45))  BEGIN
SELECT s.StocksID, p.ProductID, s.Quantity
FROM stocks s
INNER JOIN products p
ON s.ProductID = p.ProductID
WHERE p.Barcode = _Barcode
ORDER BY ExpirationDate ASC;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectStocksIndividualLogs` ()  BEGIN
SELECT StocksLogID, UsersID, UsersName, StocksID, ProductID, ProductName, DATE_FORMAT(DateAndTime, "%m-%d-%Y %h:%i %p") AS Date_and_Time, Action
FROM stocksindividual_log;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectStocksLastID` ()  BEGIN
SELECT StocksID
FROM stocks
ORDER BY StocksID DESC LIMIT 1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectStocksTotallLogs` ()  BEGIN
SELECT StocksTotalLogID, UsersID, UsersName, ProductID, ProductName,  DATE_FORMAT(DateAndTime, "%m-%d-%Y %h:%i %p") AS Date_and_Time, Action
FROM stockstotal_log;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectStocksTotalLogs` ()  BEGIN
SELECT StocksTotalLogID, UsersID, UsersName, ProductID, ProductName,  DATE_FORMAT(DateAndTime, "%m-%d-%Y %h:%i %p") AS Date_and_Time, Action
FROM stockstotal_log;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectSystemSettings` ()  BEGIN
SELECT * FROM system_settings LIMIT 1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectTransactionAnually` ()  BEGIN

SELECT TransactionID, DATE_FORMAT(Date, "%m-%d-%Y") as Date, FORMAT(Discount, 2) AS Discount, FORMAT(TotalAmount, 2) AS TotalAmount
FROM transactions
WHERE DATE_FORMAT(Date, "%Y") = DATE_FORMAT(Now(), "%Y");

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectTransactionByDate` (`_DateFrom` DATETIME, `_DateTo` DATETIME)  BEGIN
SELECT TransactionID, DATE_FORMAT(Date, "%m-%d-%Y") as Date, FORMAT(Discount, 2) AS Discount, FORMAT(TotalAmount, 2) AS TotalAmount
FROM transactions
WHERE DATE_FORMAT(Date, "%Y %m %d") BETWEEN DATE_FORMAT(_DateFrom, "%Y %m %d") AND DATE_FORMAT(_DateTo, "%Y %m %d");
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectTransactionByOneDate` (`_DateToAndFrom` DATETIME)  BEGIN
SELECT TransactionID, DATE_FORMAT(Date, "%m-%d-%Y") as Date, FORMAT(Discount, 2) AS Discount, FORMAT(TotalAmount, 2) AS TotalAmount
FROM transactions
WHERE DATE_FORMAT(Date, "%Y %m %d") = DATE_FORMAT(_DateToAndFrom, "%Y %m %d");
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectTransactionDaily` ()  BEGIN

SELECT TransactionID, DATE_FORMAT(Date, "%m-%d-%Y") as Date, FORMAT(Discount, 2) AS Discount, FORMAT(TotalAmount, 2) AS TotalAmount
FROM transactions
WHERE DATE_FORMAT(Date, "%d") = DATE_FORMAT(Now(), "%d") AND DATE_FORMAT(Date, "%Y") = DATE_FORMAT(Now(), "%Y");

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectTransactionLastID` ()  BEGIN
SELECT TransactionID
FROM transactions
ORDER BY TransactionID DESC LIMIT 1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectTransactionMonthly` ()  BEGIN

SELECT TransactionID, DATE_FORMAT(Date, "%m-%d-%Y") as Date, FORMAT(Discount, 2) AS Discount, FORMAT(TotalAmount, 2) AS TotalAmount
FROM transactions
WHERE DATE_FORMAT(Date, "%m") = DATE_FORMAT(Now(), "%m") AND DATE_FORMAT(Date, "%Y") = DATE_FORMAT(Now(), "%Y");

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectTransactionsLogForView` ()  BEGIN
SELECT t.TransactionID, t.Username, DATE_FORMAT(t.Date, "%m-%d-%Y") AS Date, FORMAT(t.Vat, 2) AS Vat, t.UserDiscounted AS User_Discounted, FORMAT(t.Discount, 2) AS Discount, FORMAT(t.TotalAmount, 2) AS Total_Amount,
FORMAT(t.AmountTendered, 2) AS Amount_Tendered, FORMAT(t.TotalChange, 2) AS Total_Change
FROM transactions t;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectTransactionWeekly` ()  BEGIN

SELECT TransactionID, DATE_FORMAT(Date, "%m-%d-%Y") as Date, FORMAT(Discount, 2) AS Discount, FORMAT(TotalAmount, 2) AS TotalAmount
FROM transactions
WHERE week(Date) = week(now()) AND DATE_FORMAT(Date, "%Y") = DATE_FORMAT(Now(), "%Y");

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectUserInformationByID` (`_UsersID` INT(11))  BEGIN
SELECT *
FROM users u
INNER JOIN users_information ui
ON u.UsersID = ui.UsersID
WHERE U.UsersID = _UsersID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectUserInformationByIDForView` (`_UsersID` INT(11))  BEGIN
SELECT u.UsersID, u.UsersType, u.Status, ui.FirstName, ui.LastName, ui.MiddleName,
 DATE_FORMAT(ui.BirthDay, "%m-%d-%Y") as BirthDay, ui.Age, ui.Address, ui.Contact, ui.Sex, ui.Image
FROM users u
INNER JOIN users_information ui
ON u.UsersID = ui.UsersID
WHERE U.UsersID = _UsersID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectUsersInfoLogForView` ()  BEGIN
SELECT UsersInformationID, UsersID, UsersName, UsersSubjectID as 'Subject_ID', UsersSubjectName as 'Subject_Name',
DATE_FORMAT(DateAndTime, "%m-%d-%Y %h:%i %p") AS Date_and_Time, Action
FROM usersinformation_log;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectUsersLastInsertedID` ()  BEGIN
SELECT UsersID
FROM users
ORDER BY UsersID DESC LIMIT 1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectUsersLogForView` ()  BEGIN
SELECT UsersLogID, UserID as UsersID, UserName as UsersName,  DATE_FORMAT(TimeIn , "%m-%d-%Y %h:%i %p") as TimeIn,  DATE_FORMAT(TimeOut, "%m-%d-%Y %h:%i %p")  as TimeOut
FROM users_log;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `testSelectEachProduct` (`_ProductBarCode` VARCHAR(45))  BEGIN
SELECT *
FROM products
WHERE ProducBarcode = _ProductBarcode;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdatePassword` (`_UsersID` INT(11), `_Password` VARCHAR(45))  BEGIN
UPDATE users
SET Password = _Password
WHERE UsersID = _UsersID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateProduct` (`_ProductID` INT(11), `_Barcode` VARCHAR(45), `_ProductName` VARCHAR(45), `_Description` VARCHAR(45), `_PurchasePrice` DECIMAL(10,2), `_SellingPrice` DECIMAL(10,2), `_Image` BLOB)  BEGIN
UPDATE products
SET BarCode = _BarCode, ProductName = _ProductName, Description = _Description, PurchasePrice = _PurchasePrice, SellingPrice = _SellingPrice, Image = _Image
WHERE ProductID = _ProductID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateProductSold` (`_Barcode` VARCHAR(45))  BEGIN
SELECT *
FROM stocks
WHERE Barcode = _Barcode
ORDER BY ExpirationDate ASC;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateProductStatustoActive` (`_ProductID` INT(11))  BEGIN
UPDATE  products
SET Status = 'Active'
WHERE ProductID = _ProductID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateProductStatustoNotActive` (`_ProductID` INT(11))  BEGIN
UPDATE  products
SET Status = 'Not Active'
WHERE ProductID = _ProductID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateStatusToExpiredByID` (`_StocksID` INT(11))  BEGIN
UPDATE stocks
SET Status = 'Expired'
WHERE StocksID = _StocksID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateStocksEmptyQtyToArchiveZero` (`_StocksID` INT(11))  BEGIN
UPDATE stocks
SET   Quantity = 0
WHERE StocksID = _StocksID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateStocksQuantityByID` (`_StocksID` INT(11), `_Quantity` INT(11))  BEGIN
UPDATE stocks
SET Quantity = _Quantity
WHERE StocksID = _StocksID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateStocksQuantitySoldByID` (`_StocksID` INT(11), `_Quantity` INT(11))  BEGIN
UPDATE stocks
SET Quantity = _Quantity
WHERE StocksID = _StocksID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateUserAccount` (`_UsersID` INT(11), `_Username` VARCHAR(45), `_Password` VARCHAR(45))  BEGIN
UPDATE users
SET Password = _Password ,Username = _Username
WHERE UsersID = _UsersID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateUsername` (`_UsersID` INT(11), `_Username` VARCHAR(45))  BEGIN
UPDATE users
SET Username = _Username
WHERE UsersID = _UsersID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateUserPersonalInfo` (`_UsersID` VARCHAR(45), `_FirstName` VARCHAR(60), `_LastName` VARCHAR(60), `_MiddleName` VARCHAR(60), `_BirthDay` VARCHAR(60), `_Age` INT(11), `_Address` VARCHAR(100), `_Contact` VARCHAR(15), `_Sex` VARCHAR(45), `_Image` BLOB)  BEGIN
UPDATE users_information
SET FirstName = _FirstName, LastName = _LastName, MiddleName = _MiddleName, BirthDay = _BirthDay,
Age = _Age, Address = _Address, Contact = _Contact, Sex = _Sex, Image = _Image
WHERE UsersID = _UsersID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateUsersAccountStatusByID` (`_UsersID` INT(11), `_Status` VARCHAR(45))  BEGIN
	UPDATE users 
    SET Status = _Status
    WHERE UsersID = _UsersID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateUsersAccountToDeactivate` (`_UsersID` INT(11))  BEGIN
	UPDATE users 
    SET Status = 'Not Active'
    WHERE UsersID = _UsersID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `ValidateUsernameIfAlreadyExist` (`_Username` VARCHAR(45))  BEGIN
SELECT *
FROM users
WHERE Username = _Username;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `ValidateUserPasswordByID` (`_UsersID` INT(11), `_Password` VARCHAR(45))  BEGIN
SELECT *
FROM users
WHERE UsersID = _UsersID && Password = _Password;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `ViewActiveUsersInformation` ()  BEGIN
SELECT u.UsersID, u.UsersType, ui.FirstName, ui.MiddleName, ui.LastName, DATE_FORMAT(ui.BirthDay, "%m-%d-%Y") AS BirthDay,
ui.Age, ui.Address, ui.Contact, ui.Sex, u.Status
FROM  users AS u
INNER JOIN users_information AS ui
ON u.UsersID = ui.usersID
WHERE u.Status = 'Active';
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `ViewAllStocks` ()  BEGIN
SELECT s.StocksID, s.ProductID, p.ProductName, s.Quantity, DATE_FORMAT(s.DateAdded, "%m-%d-%Y %h:%i %p") AS Date_Added,
DATE_FORMAT(s.ExpirationDate, "%m-%d-%Y") as Expiration_Date, s.Status
FROM products p
INNER JOIN stocks s
ON p.ProductID = s.ProductID
WHERE s.Quantity != 0;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `ViewNotActiveUsersInformation` ()  BEGIN
SELECT u.UsersID, u.UsersType, ui.FirstName, ui.MiddleName, ui.LastName, DATE_FORMAT(BirthDay, "%m-%d-%Y") AS BirthDay,
ui.Age, ui.Address, ui.Contact, ui.Sex, u.Status
FROM  users AS u
INNER JOin users_information AS ui
ON u.UsersID = ui.usersID
WHERE u.Status = 'Not Active';
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `ViewSelectedProduct` (`_ProductID` INT(11))  BEGIN
SELECT ProductID, BarCode, ProductName, Description, FORMAT(PurchasePrice, 2) AS PurchasePrice, FORMAT(SellingPrice, 2) AS SellingPrice, Image
FROM products
WHERE ProductID = _ProductID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `ViewTotalPerProductQuantity` ()  BEGIN
SELECT p.ProductID, p.ProductName, SUM(s.Quantity) AS Total_Quantity
FROM products p
INNER JOIN stocks s
ON p.ProductID = s.ProductID
GROUP BY p.ProductID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `ViewUsersInformation` ()  BEGIN
SELECT u.UsersID, u.UsersType, ui.FirstName, ui.MiddleName, ui.LastName, DATE_FORMAT(BirthDay, "%m-%d-%Y") AS BirthDay,
ui.Age, ui.Address, ui.Contact, ui.Sex
FROM  users AS u
INNER JOin users_information AS ui
ON u.UsersID = ui.usersID;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `ProductID` int(11) NOT NULL,
  `BarCode` varchar(45) DEFAULT NULL,
  `ProductName` varchar(45) DEFAULT NULL,
  `Description` varchar(45) DEFAULT NULL,
  `PurchasePrice` decimal(10,2) DEFAULT NULL,
  `SellingPrice` decimal(10,2) NOT NULL,
  `Image` longblob,
  `Status` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `products_log`
--

CREATE TABLE `products_log` (
  `ProductsLogID` int(11) NOT NULL,
  `UsersID` int(11) DEFAULT NULL,
  `UsersName` varchar(45) DEFAULT NULL,
  `ProductID` int(11) DEFAULT NULL,
  `ProductName` varchar(45) DEFAULT NULL,
  `DateAndTime` datetime DEFAULT NULL,
  `Action` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `product_transaction`
--

CREATE TABLE `product_transaction` (
  `ProductTransactionID` int(11) NOT NULL,
  `TransactionID` int(11) DEFAULT NULL,
  `ProductID` int(11) DEFAULT NULL,
  `PurchasePrice` decimal(10,2) NOT NULL,
  `SoldPrice` decimal(10,2) DEFAULT NULL,
  `Quantity` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `stocks`
--

CREATE TABLE `stocks` (
  `StocksID` int(11) NOT NULL,
  `ProductID` int(11) DEFAULT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `DateAdded` datetime DEFAULT NULL,
  `ExpirationDate` datetime DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `stocksindividual_log`
--

CREATE TABLE `stocksindividual_log` (
  `StocksLogID` int(11) NOT NULL,
  `UsersID` int(11) DEFAULT NULL,
  `UsersName` varchar(45) DEFAULT NULL,
  `StocksID` int(11) DEFAULT NULL,
  `ProductID` int(11) DEFAULT NULL,
  `ProductName` varchar(45) DEFAULT NULL,
  `DateAndTime` datetime DEFAULT NULL,
  `Action` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `stockstotal_log`
--

CREATE TABLE `stockstotal_log` (
  `StocksTotalLogID` int(11) NOT NULL,
  `UsersID` int(11) DEFAULT NULL,
  `UsersName` varchar(45) DEFAULT NULL,
  `ProductID` int(11) DEFAULT NULL,
  `ProductName` varchar(45) DEFAULT NULL,
  `DateAndTime` datetime DEFAULT NULL,
  `Action` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `system_settings`
--

CREATE TABLE `system_settings` (
  `name` varchar(255) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `contact` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `system_settings`
--

INSERT INTO `system_settings` (`name`, `address`, `contact`, `email`) VALUES
('POS with Inventory Demo\'s Store', '4 Ibarra St., Acacia Malabon City', '+639777712398 / +639104030419', 'brianbaenag@gmail.com');

-- --------------------------------------------------------

--
-- Table structure for table `transactions`
--

CREATE TABLE `transactions` (
  `TransactionID` int(11) NOT NULL,
  `Username` varchar(45) DEFAULT NULL,
  `TotalAmount` decimal(10,2) DEFAULT NULL,
  `UserDiscounted` varchar(45) DEFAULT NULL,
  `Discount` decimal(10,2) DEFAULT NULL,
  `Vat` decimal(10,2) DEFAULT NULL,
  `AmountTendered` decimal(10,2) DEFAULT NULL,
  `TotalChange` decimal(10,2) DEFAULT NULL,
  `Date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UsersID` int(11) NOT NULL,
  `UsersType` varchar(45) DEFAULT NULL,
  `Username` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UsersID`, `UsersType`, `Username`, `Password`, `Status`) VALUES
(1, 'Admin', 'admin', 'x61Ey612Kl2gpFL56FT9weDnpSo4AV8j8+qx2AuTHdRyY', 'Active'),
(2, 'Employee', 'cashier', '6YiROXGbEJPMj3F71mjPl12LzfMdNjwBCmJIcU4c5lAy/', 'Active');

-- --------------------------------------------------------

--
-- Table structure for table `usersinformation_log`
--

CREATE TABLE `usersinformation_log` (
  `UsersInformationID` int(11) NOT NULL,
  `UsersID` int(11) DEFAULT NULL,
  `UsersName` varchar(45) DEFAULT NULL,
  `UsersSubjectID` int(11) DEFAULT NULL,
  `UsersSubjectName` varchar(45) DEFAULT NULL,
  `DateAndTime` datetime DEFAULT NULL,
  `Action` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `users_information`
--

CREATE TABLE `users_information` (
  `UsersInformationID` int(11) NOT NULL,
  `UsersID` varchar(45) DEFAULT NULL,
  `FirstName` varchar(60) DEFAULT NULL,
  `LastName` varchar(60) DEFAULT NULL,
  `MiddleName` varchar(60) DEFAULT NULL,
  `BirthDay` datetime DEFAULT NULL,
  `Age` int(11) DEFAULT NULL,
  `Address` varchar(100) DEFAULT NULL,
  `Contact` varchar(15) DEFAULT NULL,
  `Sex` varchar(45) DEFAULT NULL,
  `Image` longblob
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users_information`
--

INSERT INTO `users_information` (`UsersInformationID`, `UsersID`, `FirstName`, `LastName`, `MiddleName`, `BirthDay`, `Age`, `Address`, `Contact`, `Sex`, `Image`) VALUES
(1, '1', 'Admin', 'Admin', 'Admin', '1998-08-31 00:00:00', 21, 'Malabon City', '09777712398', 'Male', 0x89504e470d0a1a0a0000000d4948445200000200000002000806000000f478d4fa0000000467414d410000b18f0bfc6105000000206348524d00007a26000080840000fa00000080e8000075300000ea6000003a98000017709cba513c000000097048597300000f6100000f6101a83fa7690000001974455874536f667477617265007777772e696e6b73636170652e6f72679bee3c1a00004a9f49444154785eeddd07bc6c5779df7dbd798948e2441242123d08538c10bd865e0c188c694e4ca806173098f28662d3b1c188167a426c3a2f5d46b41881656c0336c2d8c1a0d00ca219641904c8020981844af2fffbdec5dd33e7d9e7cc6e6bf6daebf7ff7cbe9f23eebde730fb396b9e67cdcc9e3d072d30ff42fe5fb9c408fc73fe1f213b439df364af3aff6b3956ee290f9147c993e539f2dfe40d72829c241f934fcbd7e4bb72fe7efe6fff99ffceffc6ffd6dff37a79b91c274f9247ca2f8bffbfae2d9794a584f59c27d4394f5c17d77a378bab9d0fca0be35f0ec4e2da3dd4394f9a75be9cdc561e262f94f7c9a97281fc9f2db948be2227ca8bc5b7cdb7f132525258cf79429df3c47571ad5da3c4ff3bb298f860c6585cc6e26a0f759e3697967bc813c58fdefd88fc4c8906f09c9d251f171f839f91b8b7cc7163c07ace13ea9c27ae8beb13f1ef60dd22e203f1c23878045ea42cae38d479fc1c22bf207e047d8a5c2cd1405d8acf8a5f56b8971c26db0ceb394fa8739eb8ce1ef4ae51b2d726a0e8a4ddce988babf8a24c10ea3c5efc9afd1dc5afd1fb11f285120dca1af825844fc80be42ef2539223ace73ca1ce79e23abb2eae4fc4bf8326ffdba4d83417974f461a82c5d51eea3c2caedb2de5e9f221394fa26188830efab17c549e253e97c06b66ecb09ef3843ae74973f8bbd689ff77937f174dfe9e62eb9916971746b460ba72c1585c3b439dfbe716f207e2d7c2a36187bd9d2daf93db89d7e2d0b09ef3843ae789ebecbab83eaeb5bf366db209282ecdc5f5af066271b5873a77cfd1e247fa3e3b3f1a68e8cf6f53f4330357973e613de70975ce17d7d9f571ad9bfc67c96e9b8022ebea1bee85112d98ae585ceda1ce9be5dfc9afc88765e927f0cdc5c9f21bd2e52442d6739e50e73c719d3dec5d6bebbb092826de59fac6a7c5e593a9867091585c3b439df78e8fe74ef2663957a22185e9f97c8a3f94bb89d76c14d6739e50e73c693ec3e25aaff39f276d9b80e2360069718db1b02c2d2eff5c7220d479f75c567cf6fe3f483490b03ddf9217c9952485f59c27d4394f5c0f0f6d0f7ad73ae9bb092862839516970fcc8be3df0cd05c5c6435d4b93d579657c88f241a3e980fbf93e035e2730558cfd387be9127eb756e6e00fa6c025c63ffcc59271db40f305a305db8682e4c314f7b640c758e730df159e81e2ad1b0c17cf9fa0ac7cb8d255aa79ba26fb487be9127ebc3bf296d0012ff9ba46d03e01a5735fc8dc515873aefcc75e5ede20bd544c305e5f089997f24b79668bdee85be1187be9127eb755edf00ac6f025cc7247a16a088e1eff8a07d70be3ad8502caef650e703b999fc4fe16cfe65fa53b9b3446b3742df680f7d234fda365969f8279b6c028a18fe69c7c3e29a36d4f9407ca1990f4a3434b03cfe80257f1641b48e13fa461cfa469e34ebbc3efc9bfcf749b40948c3df3fabbae1ef4214b1ebc91ceabc2f7e8d9fc15fafbf929bca52d6f3d4a16fe4c96e75de7413d0dc001433fcfd1a850fe2df0ec4e26a0f75de779b7d5539aecb8f0bc49f4ee88f2aa66fb487be9127aec75e9bac4d3600e60d807f67b37f57c5548b8bac863a1f74d05de52b120d03d4eb74b9bfd0377686be9127eb754e033fb2d72680e14f56527b9daf28ef94a8f903c949723521fb427fce93ddea9c86febadd3600450c7fc737d407b07ed07db0b8da536b9dfd74da13e41c891a3eb0ce2f0d3d53bcce6b0ffd394f36a9f3a69b00bfee5fcc23ffb117977f2e39909aeb7c2bf98c444d1ed8cb97c52f19d518fa739e74adf35e1b00863ff9496aadf3e1e22bf8f17e7e8cc12f1d5d416a09fd394ffad4797d03903601c50e7f7f9c6a5ffe7e16579c669da3da7551529d6f29df90a891037d7d476a7836a0d6be913bcd3aa739e8af9b58df0078f8fba4bfa286fffa62e9ca85488b8baca6c63afb989f287e5b57d4c081a1fc8cd2f3c4e7952c31f4e73cd9abce69d0b7690e7fff0c0fffd9d799c5952735d6f908f980444d1b18db47c5ef2a5952e8cf79d2a5ce69e0478a1afece588bcb585ced719dbd38a2ba7555429dfd212f7c3e3f72fbaefcbc2c25b5f58d6da54b9da3c19ff86714f7c8df373c3ad02ed2e2f2cf250792eaec8551439d7dbb9e22fed8d7a8410353f34b02cf97925f12a8ad6f6c2b7debec7f1ba96ef8fbfb595c719a8b2baa5d1725d4f928f1055ba2a60ce4e69704ae24a5a5b6beb1ad0ca9b3ebdae49f51449dd3418ff1b43f8bab3db5d5d99fdcf78f123562605bfc92c0dda494d09ff3648c3a573ffcfd36071f34594d6d75fe6de1297fcc955f1278b6cc3df4e73c19abceebc37fd66171e5494d75f6b1be4ca2a60bcccdeb65aee705d09ff364ec3a1731fc9d74d0bed1d1c17451cc416f21aef318afddd99cebecab5bbd4da2460bccd51f8987e3dc524bdfd876aaab7373c7e3e13f7403900eda3f971c48aaf3d88b6b8e75f61afaa0440d1698bb93c597a59e436aea1bdbcc54759e75d24137877fdf0d80bf8fc51567ccc535f73a1f299f90a8b102a5f89c6cfba24135f58d6da6ca3aa783f6d35dbed14dd181edc6df935e536271adc6d7794e9baca8765dccbdce579153256aa84069fcd914c7c8365253dfd866c6ae73f1c3dfa2836be37f9f1617594daaf3d877e239e67ac2dbfcb03467ca7f909ca9a96f6c3363d7390dff59c707ed335ddb86bf450718f1bf6571c5a9e94e7c5bf99e440d1428ddb992ebf2c10cff3ca972f83b69f8fbf50edff048749091620e7a0bf1e2aae184925f94f3246a9cc052f8d32a7f59a64e2d7d63dba9aececd47fe3ef0a11b8074d0feb9e440d2ce72ecc535c73adf4bb8c00f6ae10b064db509a8a96f6c3355d6d937cec3df37d64f790cd900f8ef595c71c65c5c73afb33fcdef4712354a60a9fc4cc05d65ccd4d437b6992aebec1b170d7ff34144a20336ff5d7a4d89c5b59ab4b8c67eed6e8e75be8e9c2551830496cee7048c7562604d7d639ba9b2cebe711efefe08421ff8900d80ff3c1d3459cd548b6b8e395a4e97a83102b5f087080d7d8b604d7d639ba9b2ce3e68dfc8e6f0b73e1b00ff990fda9b09b29a2916d75ceb7c847c51a28608d4c6d709e87bb1a09afac636536d9dd3f0f70d4ec3dffa6c00fc33d859c6f1e2722dd76bd6c79cebec75f137123542a0569f954b49d7d4d237b69d2aeb9c86bf5ff71fba01e0849238696739f6e29a639d7d9c2749d40081daf9b3037cffdd2435f58d6da6ca3afbc6f946fa93d8d2f0b73e1b007f6571c5197371cdbdcebe4d6f91a8f101d8c79f22b8d753c335f58d6da6ca3afbc63587ff900d80b1b8e2a4c5e55a460ba68b12eafc12891a1e8055af93b6d4d637b6952aebec1b973ed4203df5df7703e03ff7f77242c9ce4cb1b8e65ce7c749d4e800c49e25eba9ad6f6c2bd5d6b939fc876e00fc7ddef190d5d4b6b86e29bee849d4e400c47cb5c0e6858218fe7952fdf0f753ff4337000cfff6b8c6ae59b460ba9a7b9d2f2da749d4e000ecee3b7205716aea1bdb4c9575f6f0f72ec5c37fe806201db47752e440d2ce72ecc535d73afb769d28516303b099bf14f7de5afac6b6525b7ffe49d2f0f7c10fd900f82b8b2bce988bab944dd613256a6800ba79a144bda00b1e9cb5a7c6fefc93f886fae0876c008cc515272d2ed72c5a305d7871f9f730f73af3ba3f301e9f0f706f897ac2264ae91bdb488dfd7925e9d17fdf0d80ff3b0d7fb29aa916d79cc3ebfec0f8fc99013f23516fd84d297d631ba9b13fefc8900d80bffadfb1b876a6c6c5e563e6757f601abe52e06112f58808c3bf3d0cfffd19b20160f8b7c7f5748da205d35529cfb0fcb6448d0bc038ba9c0f504adfd8466aeccf61fa6e0018fe71d2ce72ecc5e59f3be7dc4278dd1f9896cf07b89744bda2a994be913bb5f6e7d674dd00f86b1afe2caed58cb9b8fcb452298bcb9f62e68f348d1a168071f9fa005797d2fb46eed4da9f774d970d401afe7eeb20594d5a5cde24450ba68be66b4a252cae574ad4a8004ce39d527adfc8999afbf3aed97403e0affe3b1f3459cd548bab84dc4cfcb464d4a4004ce79e526adfc8999afbf39ed9640390863f8ffc77a6e6c5e5dbf949899a1380697d598e10867f7b18fe7b64930d00c3bf3dae5bad67933e46a2c604208fe3a4b4be913335f7e78db2d706c07fcef0df99b4b3acf56cd2cbcaf7256a4a00f2f891f884c052fa46aed4de9f37ce6e1b00867f9c3117979f562a7171bd55a2860420aff70b3910fa7387441b0063f8c7498babe6b349ef20512302b01dbf2884fedc39d106c07fc6f0df99a9165749f1faf882444d08c076f83a1c7ec45b73e8cf3dd2dc0018c33f0e8b6b5f9e22510302b05d2f905a437fee99e606c0ffbdd8a73a06c6f519fb8492d272b4fc50a2e60360bb7c29ee63a5c6d09f7b266d007cc00cff9d493bcbb1175789b57eaf448d07c03c7c586a0afd7960bc0160f8c7197371f969a59217d78d256a3800e6e58e5243e8cf2384e11f272d2ece26dd97774bd46c00cc4b0dcf02d09f470ac37f67a65a5ca5c6af2b72bd7fa01cb792a586fe4c260b8b6b67de22519301304f7f2c4b0cfd994c1a2f2ece263d90abc98512351900f3e5f3769616fa3399246967c9d9a4ab79b544cd05c0bcf9bc9da584fe4c26cb988bcb4f2b2d65715d497e2c517301306f3e6fe73a527ae8cf64b2a4c5c5d9a43bf372891a0b8032bc4d4a0efd994c96a916d712729470d53fa06c17c935a4c4d09fc9646171ed9ee749d4500094e5f5525ae8cf64d278717136699c4bc9d91235130065f16704f8733c4a0afd994c92b4b3e46cd2f63c49a24602a04c2f9512427fce97ea3ef577ccc5e5a79596bab8fe4ea22602a04cdf167feecb9c437fce13d7c3c37feeeb61d4a4c5c5d9a4bbe7a61235100065bbbbcc35f4e73c690eff6a3600532dae25e61512350f00657b87cc31f4e73c690e7fd7bb8a0d008b6bf31c2c674ad43c0094ed3c394ce614fa73be34877f351b001f2867936e965f94a87100588687c99c427fce13d7c5b5f683bc2a36006967c9d9a49be73d12350d00cbf0519943e8cff9e2ba78f0278bdf008cb9b8fcb4520d8beb08e1baffc0f25d55b619fa739eb81e69f85f72ffd7c56f00d2e2e26cd26e79b444cd02c0b2fcae6c2bf4e73c591ffe556c00a65a5c35e41312350b00cbf215d946e8cf79d21cfe7e76a48a0d008bab7f8e95a8510058a65b49ced09ff3c475f660f7c0f7f0af6603e003e26cd27e79be444d02c032bd4a7286fe9c2769f87b8354c50620ed2c399bb47f4e93a8490058a6b324c700a03fe7497ae4effa78f857b101187371f969a51a17d7b5246a100096ed163265e8cf79120dffc56f007c55231f0467930ecba3246a0e0096ed693255e8cf79d21cfeaeb52d7e03e0839e6271d5987749d41c002cdb9fcb14a13fe74934fc17bf0160718d17efd2b9f63f50a71f8907c498a13fe749aab3ebe39758aad900f8868f7d4249adb9a1448d01401dee206386fe9c27cde15fc50620ed78c65e5cfeb9b5e609123505007578b68c11fa739ea43a7bd0a7e1bff80dc0988bcb4f2bb1b8f6e5fd1235050075f8980c0dfd394fda86bff5d90014f1ec0a67934e13effece91a82900a8c305e2bed837f4e73c49c3dff5719d6cc806a0881a37773cd182e9a2b9b8c8bef700470d01405d7e5efa84fe9c27d1f0efbb01f0cff183bf2a877f91673d4e14bf07386a0600eaf242e91afa739e34ebdc1cfed6670350c4f0777cd03eb068c174e562b0b35c8ddf031c35030075f9a4740dfd394fda867f9f0d40518ffcc75e5c45ec7a32c58be23c899a0180ba5c2487cb26a13fe749aa73dbf0b72e1b000f7f9faf31eb8cb9b85c2016579c5b4ad40800d46993f300e8cf79b2c9f0b74d36001efefe59c50c7f1f40b460ba7071585c715c8f874ad40400d4e971b25be8cf7912d5b939f49b36d900543bfc39a16467529d5f2251130050a757495be8cf79d256e7e6d06fda6d03e0e1ef93fe18fee49fd3acf3891235010075fa8844a13fe7c96e756e0efda6dd3600450c7fc707ed03583fe83e7ce07e5a89ec4cb3ce5f92a80900a8d3191285fe9c27bbd5391afee67f9f343700453df21f7b71f9e7920359afb3cff6f5d5bfa22600a05e87490afd394f36a97334fccddf93543bfc5d08bfdec1e2da99a8ce3792e8ce0fa06eff411cfa739e6c5ae7e6d06ff2f725cde13feb3aa783f60d8e0eb60b17819d659cb63adf57a23b3f80ba3d58e8cf79d2a5cecda1dfd41cfe7ebb5f9527fc797191d5ec56e7674874e70750b7e70afd79fa749d83cda1dfd41cfeb3af33c33f4ff6aaf39b24baf303a8db7b84fe3c6dfaccc1e6d06ff206a088e1eff8a07d83a303ec2abda6447666af3affb544777e0075fb82443da32bfa737bfaccc168f85b518ffc7dd0bed1d10176c10925719a758eea96fc9344777e00753b5ffc4e80a86f6c8afe1c67d3fe1c591ffc56dcd3febed1d1c16dcadfcfe28ab3e9e2ba8a44777c00b0eb4bd43bf6427f6ecf90e16f69e89b7f4611754e073df66b4a2caed574a9f3ed25bad30380dd4ba2deb11bfa737bc698830c7ff14193d574adf33d25bad30380f9ad8051ef68437f6ecf5873707df8cf3a0cff3ce953e7074a74a707007ba444bd23427f6ecfd873b088e1efa483f68d8e0ea68b620e7a0b719dbbbea6f47089eef400604f94a87744e8cfede9d39fdb14f7c8dfc37fe806201db47f2e399054e73e8beb0912dde901c09e2d51ef58477f8e33a43f478a1dfe7d3700fe3e16579ca18beb9912dde901c05e2a51ef48e8cfed1973f81753e774d07e2d280dfe243ab0ddf87bd26b4a2caed5f83acf699315d56e132f92e84e0f00f61a897a87d19fdb33467f4e5ce7e287bf4507d7c6ff9e134ae2a43a0f5d5caf94e84e0f0076bc44bd83fedc9eb1fab3b9cec53ced7f09691bfe161d60c4ff96c51567ccc5f51689eef4006027ca7adfa03fb7a7cae1efa4e1efd73bd2c05f171d64a49883de42bcb8c63aa1e4bd12dde901c03e22eb7d83fedc9e31fb73718ffc7de0433700e9a0fd73c981a49de5988beb4f25bad303807d52d6fb06fd7967a6e8cfb3afb36f9c87bf6fac9ff218b201f0dfb3b8e28cb9b89a75feb844777a00b05365bd6fd09f5733557f9e759d7de3a2e1df6703e0bf4baf29b1b8569316d758af2935ebfc3989eef40060ff28f4e7f64cd99f671bdf380f7f7f04a10f7cc806c07f9e0e9aac66aac595f20d89eef40060e708fd39ced4fd7996f141fb4636877fdf0d80ffcc07edcd0459cd148b6bbdce7f2fd19d1e00ecfb427fde991cfd799649c3df3778e806a0881dcf96e2c5e55aaed7ac8fb63a7f46a23b3d00d869427626477f9e5dd2f0f7ebfe4337009c501227ed2cc75e5c519d3f26d19d1e00ecf3420e24677f9e4d7ce37c230f9634fcfb6e00fcb58883de42c65c5c9bd4f92489eef400607f2d645f72f7e759c437ae39fc876c008ce11f272d2ed7325a305d6c5ae71324bad30380f95a21643bfd79ebf18d4b1f6a909efaefbb01f09ffb7b39a16467a6585c9bd4f9f512dde901c0de2db5675bfd79eb690effa11b007f9f773c6435db5c5c2f97e84e0f00f646a939d50f7f3ff53f7403c0f06f8f6bec9a450ba6abae753e4ea23b3d00d82ba4e66cb33f6f2d1efedea578f80fdd00a483f64e8a1c48da598ebdb8bad4f94912dde901c09e2735660efd792b49c33f3dfaefbb01f057867f9c3117d7904dd62325bad303803d556acb5cfaf356e21bea831fb20130867f9cb4b85cb368c174e1c5e5df43df3affb244777a00b0c7484d99537fde4ad2a3ffbe1b00ff771afe6435532daebeb9b744777a00b05f915a32b7febc950cd900f8abff1dc37f67e6b8b8ee28d19d1e00ec3f490d61f8efcf900d00c3bf3daea76b142d98aec67a86e54612dde901c07e566ac81cfbf356d27703c0f08f937696632f2effdca13954a23b3d00d89565c999737fde4aba6e00fc350dff620f7aa28cb9b8fcb4d2148beb9b12ddf101d4ed87b2e49e5e427fce9e2e1b8034fcfdd641b29ab4b8bc498a164c17cdd794c65e5c1f96e8ce0fa06ea7c852534a7fce9e4d3700feeabff34193d54cb5b8a6c82b25baf303a8dbf1b2c494d49fb367930d401afe3cf2df99d216d76325baf303a8db33656961f8ef914d36000cfff6b86e259d4dfaf312ddf901d4edfeb2b494d69fb367af0d80ff9ce1bf33696759dad9a43f2dd19d1f40dd6e284b49a9fd397b76db0030fce38cb9b8fcb452cec5e5dfe77912350000f5722f5a424aeecfd9136d008ce11f272dae92cf26fd8c440d00409d4e93256409fd396ba20d80ff8ce1bf33532daedc3941a22600a04e7f2aa56729fd396b9a1b0063f8c759d2e23a4ea22600a04eaf9092c3f0ef99e606c0ffbdd8a73a06c6f559cad9a40f92a80900a8d3a3a5e42ca93f674dda00f88019fe3b9376964b3a9bf4c61235010075f22785969825f6e7acf10680e11f67ccc5e5a795e6b2b8fc3b3f47a24600a02e1788fb5369596a7fce1a867f9cb4b8967a36e9fb256a0600eaf231292d4befcfd9c2f0df99a916d79cf204899a0180ba3c5b4a4a0dfd996c29b52c2e5ff52b6a0600ea720729250c7f3269bcb86a389bd46ff53c53a28600a00e3f12f7a952524b7f2699937696359d4dfa2e899a02803afcb994901afb33c9943117979f562a65713d4aa2a600a00e4f93b9a7d6fe4c32242dae1acf263d46a2a600a00e379739a7e6fe4c26ce548baba47c53a2c60060d97c2d105f1364aea13f93c9c2e2da97b748d41c002cdb8932d7d09fc9a4f1e2e26cd2830efa35899a0380657bbccc35f4673249d2ce92b349f7e52a12350700cb7603995be8cff952dda7fe8eb9b8fcb4d25216d7a912350800cbf42d99db00a03fe789ebe1dffd9ccfff183d69717136e9ce3c5da2260160995e2c730afd394f9ac3bf9a0dc0548b6b29395a2e96a85100589eebcb5c427fce93e6f077bdabd800b0b836cb87256a140096e5d33297d09ff3a539fcabd900f840399b74effcaa44cd02c0b2f89340e712fa739eb82eaef5c1fbbf2e7e039076969c4dba597c8ce74ad430002cc3857279d976e8cff9e2ba78f0278bdf008cb9b8fcb4522d8b8b8b0201cb76926c3bf4e73c713dd2f0bfe4feaf8bdf00a4c5c5d9a4dd7367899a06806578806c33f4e73c591ffe556c00a65a5cb5c427899c2e51e30050b6b3c5bd715ba13fe74973f8fbd9912a36002cae71f27c899a0780b2bd5eb615fa739eb8ce1eec1ef81efed56c007c409c4d3a3cc74ad43c0094edf6b2add09ff3240d7f6f90aad800a49d2567938e974f48d4400094e9ebb28d9e467fce13d7c303ddf5f1f0af620330e6e2f2d34a2cae7d79a4444d0440999e25b9437fce9368f82f7e03e013d67c1063bfa6c4e2da57d36f4bd4480094c5d7f738527286fe9c27cde1ef5adbe237003ee82916173990274bd44c0094e5259233f4e73c8986ffe237002cae3c3954ce92a8a10028c3797205c915fa739ea43abb3e7e89a59a0d806ff8d82794909d719d9f2b51530150863f909ca13fe789eb9c867f151b80b4e3197b71f9e7920369d6f9cac2e7030065ba40fc51df39427fce9354670ffa34fc6dd11b803117979f566271c589eafc72899a0b80797b83e408fd394f529dd787bff5d90014f1ec0a6793e6495b9daf2e7e1d316a3000e6e922f919993af4e73c49c3dff5719d6cc806a0881a37773cd182e9a2b9b8c86af6aaf3ab256a3200e6e9ed3275e8cf79120dffbe1b00ff1c3ff55fe5f02ff2acc789b3499daf257e3d316a3400e6e562b9ae4c19fa739e34ebdc1cfed6670350c4f0777cd03eb068c174e562b0b38cb3699ddf2c51b301302fef95a9437fce93b6e1df670350d423ffb1175711bb9e8ce95ae71b8a5f578c1a0e80f9b8894c15fa739ea43ab70d7f4bc3dff6da0078f8fb7c8d5967ccc5e502b1b8e2f4adf39b246a3800e6e15d3255e8cf7992eabcdbf0b734fcad6d03e0e1ef9f55ccf0f701440ba60b1787c51567489dfd9ee27f92a8f100d8ae1fc895648ad09ff324aa7373e8376db201a876f87342c9ce8c51e7c748d47c006cd76fcb14a13fe7495b9d9b43bf69b70d8087bf4ffa63f8937fce58753e44fe46a20604603b3e2bbe7f8f1dfa739eec56e7e6d06fda6d0350c4f0777cd03e80f583eec307eea795c8ce8c59e79bc98512352200f9dd5aa608fd394f76ab7334fccdff3e696e008a7ae43ff6e2f2cf250732559d5f2a51230290d71497fca53fe7c926758e86bff97b926a87bf0be1d73b585c3b33659dfd67a74bd49000e4e193728f9431437fce934deb9c06fe3a7f5fd21cfeb3ae733a68dfe0e860bb7011d859c6c951e7ff2c51530290c76fc898a13fe749973aa781bfae39fcfd76bf2a4ff8f3e222abc959e73f91a8310198d6c765cca64f7fce93ae754e037f5d73f8cfbece2cae3cc95d673e2d10c8cf27e1de40c60afd394ffad4390dfc75de001431fc1d1fb46f7074805da5d794c8ce6ca3cecf94a8490198c6cb64ccd09ff3a44f9da3e16f453df2f741fb464707d8052794c469d639aa5b575deaec85788a448d0ac0b84e15df47c7c836fb464d1952e7f5c16fc53dedef1b1d1ddca6fcfd2cae3863de89fbd6f91a72b6440d0bc038fc72dbf5658ccca16fd490a175766d13ff8c22ea9c0e7aecd794585cab99539def2751d302308e47c818a13fe7c9187566f88b0f9aac668e757e95448d0bc0307f286384fe9c2763d5797df8cf3a2cae3c996b9dfd733e2d510303d0cf97c59fc33134f4e73c19bbce450c7f271db46f7474305d1473d05b88eb3cc66b7736769daf29fe68d2a89101e8e67cb9918c9139f78d25a5ba3a37773c1efe433700e9a0fd73c981a43a8fbdb8c6aef303256a6600ba79940c4d297da3f44c55e759271d7473f8f7dd00f8fb585c71c65c5c39eafc5a891a1a80cdbc5386a6b4be516aaaac733a68bf16e41bdd141dd86efc3de9352516d76a7cc9cfb4c98a6ad745ae3afbb6fa73caa3c60660775f954365484aec1b2566ec3a173ffc2d3ab836fef7697191d5a43a8f7d27ce916bc9b91235380031bfee7f13199292fb464919bbce69f8cf3a3ee84b48dbf0b7e80023feb72cae384bb813fbfa00174bd4e800ecf4701912867f9e5439fc9d34fcfd7a876f78243ac8483107bd8578712de18492c749d4e800ac7a960ccd52fac6dc535d9d9b8ffc7de0433700e9a0fd73c981a49de5d88b6b9b757e81440d0fc03eaf94215962df9863aaacb36f9c87bf6fac9ff218b201f0dfb3b8e28cb9b8e65467ffffbf41a2c607d4ee5de2fb69df2cb56fcc2d55d6d9372e1afee6838844076cfebbf49a128b6b3569718dfddadd5ceaec3574a2440d10a8d547c4bdb56f96de37e6922aebec1be7c6ed8f20f4810fd900f8cfd34193d54cb5b8e6161fdfc7246a84406dfeb70c79bb5f2d7d63dba9b2ce3e68dfc8e6f0b73e1b00ff990fda9b09b29a2916d79ceb7cb87c5ea28608d4e26b7239e99bdafac6b6526d9dd3f0f70d4ec3dffa6c00fc33d859c6f1e2722dd76bd6472975be929c2651630496eedb727519921afbc63652659dd3f0f76b534337009c501227ed2cc75e5ca5d4d9170a3a53a206092cd5397263e99bdafb46ae545967df38dfc883250dffbe1b007f6571c5197371955ce79b0b570b442d7c95bf3b49dfd037f2a4ca3afbc63587ff900d80b1b8e2a4c5e55a460ba68b25d4d99b009e09c0d29d2d7794bea16fe4499575f68d4b1f6a909efaefbb01f09ffb7b39a16467a6585c4ba8f331f20d891a2750ba3364c8e7fad337f2a4da3a3787ffd00d80bfcf3b1eb21aeec4bbe78af239891a28502a7fb2dfd5a46fe81b7952fdf0f753ff4337000cfff6b8c6ae59b460ba5a6a9dfd1641ae1380a538452e2b4342dfc8932aebece1ef5d8a87ffd00d403a68efa4c881a49de5d88b6ba975f61a7b9f440d1528c587e410e91bfa469e545be734fc7df0433600fecae28a33e6e2aa6993e575c96707a0542788fb68dfd037f2a4ea3afb86fae0876c008cc515272d2ed72c5a305d7871f9f7505b9d9f2f518305e6eaf7c50faefa86be9127d5d7393dfaefbb01f07fa7e14f5633d5e2aa318f958b256ab6c09cfcae0c097d234fa8b3326403e0affe772cae9d61718d9ffbca0f246abac0b69d27bf2e4342dfc813eabc3f4336000cfff6b89eae51b460bae2199603b9a67c46a2060c6ccb97e4063234f48d3ca1cefbd37703c0f08f937696632f2eff5cb22f5e8baf96a81103b91d2f43cef477e81b79429dd7d27503e0af69f8b3b85633e6e2f2d34adc89e3a43affaaf09200b6c54ff93f428686be9127d43948970d401afe43ce6e5d6ad2e2f226295a305d345f53e24ebc9af53afb69d74f4bd4a081a9f829ffebcbd0d037f2843ab764d30d80bffaef7cd06435532d2eb29ab63a1f29af95a85103637bbb78dd0d0d7d234fa8f32ed9640390863f8ffc7786c595279bd4f921e2cf598f9a3630d48fe4e13246e81b79429df7c8261b00867f7b5cb7b14f28213bb3699daf27bef67ad4c081be4e95319ef24fa16fe40975de237b6d00fce70cff9d493bcbb117977f2e39903e753e428e133f628b9a39b0a90be445e2477f6384be9127d479c3ecb601f09f31fc7766ccc5e5c6c29d38ced03a5f573e28516307f6f251b98e8c15fa469e50e70e893600e6ffcdf0df99b4b8c67e4d893bf16ac6acf303e574899a3cb0ee3bf22b32e67d92be9127d4b963a20d80ff8ce1bf33532d2eb29a29ea7ca8f8a95c3fa51b357dc09f35f14a395cc60c7d234fa8738f343700c6f08fc3e2ca93a9ebec97054e966800a05e9f949bc9d8a16fe40975ee99e606c0ffed42929d717dc63ea184ec4c8e3a7b8dfb2a82df956818a01edf9747cb54f747fa469e50e79e491b001f30c37f67d2ce72ecc545ad57b38d3a5f5afc9902174a341cb05c7ebaffcd72599922f48d3ca1ce03e30d000b2bce988bcb4f2b71278eb3ed3a5f55bc11385fa26181e5f066ef4d722d992af48d3ca1ce23848515272daeb15f53a2d6ab99539daf282f971f4a343c502e6fee7c82df4fcb94a16fe409751e292cac9d996a7191d5ccb5ce47c9f3e46c898609ca71aebc54ae205387be9127d4994c1616579e9450e74bc933e44c89860be6cb27f73d47fc41513942dfc813ea4c268d17d7d82794909d29a9ce6e14bf25df9468d8603efcce8ea7c9619233f48d3ca1ce6492a49de5d88bcb3f971c48c975f6ffd7c3e4af241a3ed89ebf15bf9dcfeb2a67e81b79429dc964197371f9d1228b2bce92ea7c0d79b67c5da28184e9f9f2ce2f9063651ba16fe409752693252daeb15f536271ad66a975f6ffffede5f5728e44830ae3f13b34de223f27fefd6f2bf48d3ca1ce64b24cb5b8c86a6aa9b31fa13c48fc0984174934c0d09d2fdaf311f1d51b0f916d87be9127d4994c1616579ed45a675f53e049f25989861af6f645f1bb30ae2273097d234fa83399345e5c63bca664e93525b233d479df66c0cf0cf86502ce1968e7d7f47d795e3fd2bfb2cc31ace73ca1ce6492a49de5d88bcb3f971c08756ecfd5c4ef2678bb9c21d130ac81dfb27782fca65c53e61cd6739e50e77ca9ee537fc75c5c7e5a89c515873a77cbb5e531f21e394ba261b904beb2e2fbe471727d29e5f7c97ace13ea9c27ae8787bf3f07a89aa4c535f66b4a2caed550e761f11df3ba721ff1ebdf3ee3ddef712fe91d06befceea7c4cf70fcaedc4f6e2025361cd6739e50e73c713dd2f0af660330d5e222aba1ced3c6d7b3ff5979a4fc77f953394d7c967c3488a7f60ff267f20af133187716bf76bf94a6cb7ace13ea9c27ae731afeae77151b0016579e50e73c89eaec0f2fba99f8bdf1ff511e228f12bf0be1387999bc56fe50de2f7f217e84fe253955fc0cc387e47fca5bc59f9af742f91df1d3f50f95fbcadde436723df1ef68c9613de70975ce97e6f0b72a36003ed0b14f28213b439df3843ae70975ce13ea9c27ae8b6b7df0feafb6e80d40da598ebdb8fc73c98150e73ca1ce79429df3843ae78bebe2c19fb8eeb6d80dc0988bcb4f2bb1b8e250e73ca1ce79429df3843ae789ebe1ba78e85f72ffd7c56f00d2e21afb352516d76aa8739e50e73ca1ce79429df3c4f5705dd2f0af620330d5e222aba1ce79429df3843ae70975ce13d7d975f1b0f7b323556c00585c79429df3843ae70975ce13ea9c27aeb307bb07be877f351b001fd018af29597a4d89ec0c75ce13ea9c27d4394fa8739ea4e1ef0d92eb648bde00a49de5d88bcb3f971c0875ce13ea9c27d4394fa8739eb81e1ee8ae8f877f151b803117979f566271c5a1ce79429df3843ae70975ce13d7637df82f7e03e0ab1af920c67e4d89c5b59ab1ea7c19b99dfc67f90d798abc489e2bbf26bec2dce5a5d6fab39ef3640e757613f6a71ffe823c507e49ee21be94f2cde510293dace73c713dd2f077adcdb5b2c56e007cd0532c2eb29abe753e5adcd09e2eef105f6ef62289ae27bfee4cf1a5686f2db5dcd959cf79b2ad3a5f5a7e557ca9e5afc95ef7057fb6c397c5f71d6f94ef2a979552c27ace13d7797df89beb658bdc00b0b8f264d33a1f2bf797e789af33ef0f88899a5a1f7f2fcf92253c226a0beb394f72d7d9cdd543ff83728144ebbbab6f8aef63fe7c87ff2457151fd79cc27ace935467d7c72fb1b8de89ffcc16b901f00d1fe335257371585c71d6eb7c98dc547e5dfe9b7c44727d76bd1bdf036489613de749ce3adf493e27d15a1edbf7c5f7457fe0933f04ca1fd4e463dd5658cf79e23aa7e16f8bdf00a41dcfd88b6b6e3be86da759673f95ff70f15397fe8cf7a801e5f461b9962c21ace73cc959673f227faf446b37a71f8aefb3deacfbdc9b1c613de749aab307bd6b9d2c7a0330e6e2f2d34a2cae38ae8707ac5f77fc986cfaba7d4ee78b3fe6d6bfbf52c37ace935c75f6ff7eb4cc6193bccef761df979f283ef1708ab09ef324d5797df85b9f0d40113d94b349a78deb7b0b79817c41a22632471f97a91ada94613de749ae3afb59b23f97688dced117c5f7f55b8a6b3434ace73c49c3dff5719d6cc806a0881aa7831e7b71d51ed7f39ef23af9b6448da2043f92c7cb188d2c4758cf7992abce0f9373245a9b25f07ddf3dc0bdc0b5ea1ad6739ea43abb3eae53d26703e09fe3a7fefd33679d29165791673d8e14bf16e8d704fddaa05f238c1a42a93e2a57973987f59c2739ea7c45f96389d662a9dc137cfe82dfb97094ec15d6739e34ebec3a35f5d9001431fc1d1fb40f2c5a305db91835ee2c7dccf7923f13bfb738bae32f855f7f7d8ccc7571b39ef364ea3a3f58be27d11a5c0a9f377092f842456dcfaeb19ef3a46df8f7d9001431fcd38e67ecc555c4ae67a41c2ebf2d7e1f7d74075f32bf53e02a3297b09ef364ea3afb423c7ef62c5a734be60b123d560e1587f59c27a9ce6dc3dffc3b48f6da0078f8cffea5d23117970b54dbe2f27b805f234b7b8abfab1fc853c58b7f9b613de7c9947576e3f4334bff24d15aab85ef53ff43ae23ace76993d6f36ec3dffc7b48da36001efefe59c50c7f1f40b460ba70716a595c6e50be2a982f0612dd716bf675b9af6c23ace73c99b2ce7e0abca477c6e4e2773ddc47fcac4054c7bdb09edb13ad67d72bb2c906a0dae1efc1b8e41c297ebffe6912dd4971c0c9e2ab18e60aeb394fa6aaf3b5e54f245a4b38c09f6bf064f14991514d23ace7f6b4ad67d72cb2db06c0c3df27fd31fc17961bc91be43c89ee9488f924c837899bd594613de7c91475be9cfc815c28d11a42cc27e0faa5c79b4854df84f5dc9eddd6b3eb16d96d0350c4f0777cd03e80f583eec307eea7959616df61fc54b61fc94677406ccecdea77c4779429c27ace9331ebeccfb9f095f27c5dfd68cd60731f127fe477f4f200ebb93dbbade768f89bff7dd2dc0014f5c87fac3b715a5cfeb94b8a2fd2e1ab77457736f4e7974efc96aeb11e8db09ef364cc3a7b483d48be22d11a417fa7c8dd24d59af51c6793f51c0d7ff3f724d50e7f17c2af772c6d71f9a97ebfa52dba73613c7eaba4cff2f65aec1bd6739e8c55e723c4d7eeff92446b02e3f1c7175f5758cf3bb3e97a6e0efd267f5fd21cfeb3ae733a68dfe0e860bb701196b6b3bc92f8b5eaa55fb8676ebe2bcf140f872e613de7c91875be82f8e59f6f49b406308d0bc41f21def5beb5e47459cfcda1dfd41cfe7ebb5f9527fcb9592e2187c873c4d7b78fee44c8c3d750f8efb2c9c58458cf7932b4ced790974ac9d7ed5f025f41f1b7c4c3aae6745dcfcda1dfd41cfeb3ef1b34cb387e0dfa11728644771a6c87cf047f9bdc40a2b09ef364489dfd32da1bc51f211dfd8eb11d5f159f285863faace7e6d06ff206a088e1eff8a07d83a303ec2abd465a7a7ca191cf4b7427c17c7c50fc2e0cafbb14d6739e74adb32f83eddfd589c2cb68f3f6577273a9297dfa4634fcada847fe3e68dfe8e800bb58c209527e54e90fe889ee14982f3f85f96ab99d8c3dfc4b5ecf53a4d937a2baadbb8dbc527c2e47f4bbc37c1d2f73fafc8e29d2753d37ad0f7e2bee697fdfe8e8e036e5ef2fbd59fa24245fc4c79fb615dd11500e5f05cde76cf8aa71d17addcb12d6f354d9b4595e537c521f97eb2d9f2f6cf65f257de8d0923264f85b1afae69f5144df48073df66ba425364b9f9de90b8dd4fe213d4be4a7997d81a647cae5255abfeb4a5fcf5366afbe711979a8f87af46ca497c7cfe03c40969231e620c35f7cd025e6df0befe7af833778ef93ff22c7ca12d7f39469eb1b7ea4ff28798ff853e9a2da6359de2abe4263c9196b0eae0fff5987e17f20f717bf6e1c2d702cdfa9f2fbf28b729430fcdbd3ec1b7ebff83de4e5c249b2f5f2a779de564accd873b088e1efa483f68d8e0ea68b620e7a2ddeb97a071b2d6ad4c9d777f0bb091e2fc708598d6be2da9c24bc5486c42ff33c4f3c574a8a6f6fdfd7fcd715f7c8dfc37fe806a088d73a82f80cf16f48b49881c46be40fc5e786dc51fcf6b55ae20df2ede509e28db24fa88c6a04249f14bf1434f7a43958fdf0efbb01f0f79538fc7d1de6e70b2726a12f0fc213e429f27372a4941e6f6cbcc1f146c76ff7fab2f0fe7cf4e167867e53e69a31877f3173301db45fdb6c0e7f8b0e6c37fe9ef41a6949c3ff5af22989162d30849f2978afbc587c72a1cf27f015eee6b439b8b4dc50ee25fe60a517cabb8447f698822ff2e47783cc297ea7577a101ccdb62e3c078b1ffe161d5c1bfffb124f90f2d9c95cbf1fdbe04744fea8689f5bf01a79863c443c88ef2cb7120f66bfbe7e65f1a6c18f4ea2a6e23f73f3f209787ee78a9f6ef5f7fa67f867f967fae3939f26be18925fabff3b3957a2db064ce9db72779943d21c1c7bf8cf3a3e685fc7be6df85b748011ffdbd286ff65e503122d4e60eebc693d53fcbe6b4eba43a9fc2e1b0fde6da5cae1efa4e1ef4714cda1df141d64a49883de1f3f1afa8e440b1200908faf04e997c5b6110fffea4ef86b0effa11b80225eebd81fbfcee3f726478b1000b01d3f969c2708a647fe630fff59cfc134fc7d63fd94c7900d80ffbea4e1efe3f5c958d1e203006cdf0b64ea7932e6f02f660eb60dff3e1b00ff5d7acdbf84e1ef93a7fe5aa2050700980fbfddd49f963745d2f01feb35ff22e6601afe2eaa0f7cc806c07f5ed2097f5717bf77395a680080f9f90b19fbe25a530dff59c707ed1bd91cfe7d3700fe331fb4371325e416c2e78b0340797c72e055648c4c31fc8b988369f8fb060fdd0094f4c8df175ce1fdfd0050ae6fc98d6568c63ce1af98399886bf5ff71fba0128e9843f5f718d4bfa0240f97cb1aabe170d4a8ffcc71efeb39e83e9697f5fdf3e0dffbe1b007f2de2a015bfcdef25122d220040992e944748978c39fc8b9983ebc37fc806c04a19fe3e4e7f104bb4780000e5f307b66d328bd2f0f7ac8b067a17c5cc41dfb8f4a106e9a9ffbe1b00ffb9bfb784131dfc6126274bb4600000cbf136f17c6bcb14c3bf8813fe9ac37fe806c0dfe71dcfdcf3d3e20f5489160a0060793e229792f5543ffcfdd4ffd00d4029c3df67879e21d10201002c973fcdd29f7cd98c67a0675a34d0bb2a650efef3f0f72ec5c37fe806201df4ac5feb508e157f1a5ab4300000cb77aa5c46d223ffb187ffdce7e04f867f7af4df7703e0afa51cf4d172ba440b0200508f4fc91132c6f02fe941f03fc737d4c37fc806a0a4e1efddde97245a080080faf824f0a3241aea9bf2f0f79c2c66f83be9d17fdf0d80ff3b0dffb9e750f16e2f5a0000807afd89f8f303a2e1be97e6f02f2a433600feea7f57c241fbf6fb0322a25f3c0000ef103f508c867c9b6287bf33640350caf0f731fe9144bf70000092d74834e8db94f20c7898be1b805286bf5f8b799344bf680000d6fd578986fdba34fc8b79cd7f3d5d3700fe9a867f0907fd32897ec10000b4798a4443df8a3bdbbf2d5d360069f8fbad8325e41912fd620100d8cb6f4a34fc3d0b8b1ffecea61b007ff5df95f0b4bff348897ea100006cc29f22f8008986ff22b2c906200dff521ef9df4f2e96e8170a00c0a6ce977bc8e286bfb3c906a0a4e17f57f9b144bf480000bafa81dc5a1635fc9dbd3600fef35286ff4de55c897e810000f4e5cf8eb9a62c2abb6d004a1afefe68c7bf97e8170700c0509f11bf0cb098441b002b69f83bef96e8170600c0585e2b8b49b401f09f9534fc1f2dd12f0a0080b1fdb22c22cd0d809536fc6f283e4b33fa25010030369f14788c149fe606c0ff5dd2850dfcbe4c3eda170090db67c557c72d3a690350e2558dde26d12f060080a9bd418a8e3700250eff874af40b010020978748b12971f85f5b7e28d12f0300805c7ced9963a5c89436fcfd9acbe725fa450000909b67d24f099938af93e8170000c0b6bc51c88479a04485070060db7e4dc804b9869c2351d10100d8369f9b761d2123c61f4a748a44050700602ebe20fee86032525e2151a10100989b370b1921b7948b252a3200007374772103e28b147d5aa2e2020030575f17de1a38208f97a8b00000ccdd8b84f4c81585b3fe0100a5ba50ae2f73ccac3ff5f71d121514008052fc8dcc69d8faeabfbe3d7e897d96b98b44850400a0348f9639a439fc67b901f07bfebf2c5111010028cdf7e50ab2cd3487ffbfdcff757679a644050400a054ef946da639fc67b901b8ba9c2751f1000028d9b6ae0de08ffdf7d03f78ffd7596e004e92a8680000946e1bd706f0f0f7e04f66b901b88f440503006029725d1bc0aff9a7e17fc9fd5f67b901f08ee874898a0500c052f8da00c7ca94591ffeb3de00fc96448502006069de2a53a539fcfdaeba596f00feb57c4ba2220100b0347e16e0aa32763cfc3dd83df03dfc67bf01788c4405020060a95e2563270d7f3fb09efd06c037e634898a0300c0529d2f635d1c283df2f7c0f7f02f6203f030890a0300c0d2bd4486261afeb3df00f8fffcab1215050080a53b578e90be690eff7fb35f111b80074b541000006af17bd227d1f02f6203e06b127f51a2620000508bb3e410e9120f7f0f710f7a5f47a7a80dc07d252a040000b57992744973f817b501f0cee5331215010080da9c211eda7b253df2f7a04fc3bfa80dc0bd252a000000b57ab4ec96b6e1df7703e0ab0566cfdf4a74f00000d4ca9f14e8c11ca5f99affbfdd6fc806c0c3df3f336b6e21d181030050bb7bc97aa2e1df7703e09fe3a7feb30f7fc7173d880e1a0080dabd5e9a693eeddf1cfe7d37005b1bfe0e97fd050020f61d690ee8b6e1df6703b0d5e1ef1b101d300000d8c7437bb747fe49970d8087bfafbfb3b55c5aa283050000fb7878ef35fc6d930d8087bf7fd65687bf7379890e1600001c74d0459206f9bfdb2f1afeb6c9066016c3dff1531ae74874d00000d4ee64690effbe1b000f7f9ff4378be19fe2838b0e1a0080da3d5d9ac3bfef066076c3df79a144070d0040cdce97ebcad00dc02c87bf736d890e1c00809a1d27ebc3bfeb0660b6c33fe5af243a7800006af459395c866c00d2f0dfda7bfd37c9dd242a000000b5f199ffb79368f85b34fcad39fcfd76bf593ff277d2c50d4e90a8100000d4e495120dfe241afed61cfe5bf964bf2e695ed9e86af23d898a0100400dfe517c8d9c68f027d1f0376f008a18fe8e87bf6f703a287ff671541000006af040690efb4834fcada847fe1efebed1e9a00e11ae0b0000a8d107a439e8dbac0f7e2bee697fdfe8f503bb91f8bd8f5171000058a273e518599f8991e6e0f703695fe5cfc37fd667fb37877f7450c973242a1000004bf41489e66164b1c3dffc29815f94a84800002cc9ff96c3249a8791f5e13feb7419fec9cfc9c512150b008025f07bfe6f2bd11c6ce30d4011c3dfd9ed35ffddbc5ea2820100b0047bbde73f52dc23fff49a4574306dae286748543400004ab6c97bfed7153bfcbb6e00ec2112150e0080926df29effc4f3b3a813fefc19c4cde1df6703e0ef798f44c50300a044c74b34f3229e83c50f7f8b0eae8dffbd7fce91729a44450400a0245f95cb4934f7d6790e16f3b4ff25a46df85b748011ff5bff9c74d0b7119f2d191513008012fc58363debdf73b088e1efa4e19f2ef11b890e32121df4ef49545000004af03489665ea4b847fe1efe4337006daf75f8ffe363121515008039fb33f167de44736f5ddb1c9c55d2f0f78df519ff433600fefbbd0efa68e16383010025f9b65c55a2d9d7b4c91c9c45da867f9f0d80ff2ebde6bfd741df57a20203003037beaaedbd259a7d4d5de6e0569386bf3f82d0c37fc806c07fde3ce16f937095400040095e2ed1ec6bea3307b7120f7fdfc8e6f0efbb01f09ff9a0bd99e812ff7f9c2a51b1010098834fc9e1b23efb9afacec1ad240d7fdfe0a11b80213b9e1bc9f912151d00806dfa815c4fd6e7deba221ef93b69f8fb75ffa11b80314e74788244850700609b1e2acd991749c37ff6aff9fb461e2c69f8f7dd00f8eb5807edef3f51a2e20300b00d6f91f561df34e61c9c34ebc37fc806c0c63ee843e58b12fd120000c8e9d372944483dfa6988393c437ee5f88afef9f9efaefbb01f09ffb7ba738d1e118395ba25f06000039f83a35d79168f09b67a167671127fc3587ffd00d80bfcf3b9ea9720ff1fb2da35f0a000053f2fcf9258906bf790e1637fcfdd4ffd00dc0d4c33fe51912fd62000098d2f3251afc49ae3938381efedea578f80fdd00a483cef15a87ff3fde2dd12f07008029f83aff3e1f2d1afc96730e0e4a1afee9d17fdf0d80bf6ee3a05deccf49f44b0200604cdf902bcbfad0b7dc0f8207c737d4c37fc806605bc33fe56a729644bf2c0000c6709edc46da86bfe76431c3df498ffefb6e00fcdf69f86f3377918b24faa5010030d42364afe15f54866c00fcd5ff6e2e07fd44897e6900000cf14259d4f077866c00e634fc53de2ed12f0f00803e4e904324da00cce119f0dee9bb0198e3f0777cdb4e91e897080040171f972365b7e15fcc6bfeebe9ba01f0d734fce77ad047cb7725fa650200b089af8ae7c9fae02fee6cffb674d900a4e1efb70ece3d77900b25faa50200b09b7f921b4834fc3d0b8b1ffecea61b007ff5dfcdf169ffb6fc17897eb10000b4395ffcceb2dd86ff22b2c906200dff121ef9afe78d12fd82010088fc9a2c7ef83b9b6c004a1dfe8e8fe38312fd920100687aaaac0f7ff32c5cd4f077f6da00f8cf4b1dfe293e79f1c312fdb20100b0e7c86ec3bff8d7fcd7b3db066009c33fc54fdf7c4ca25f3a00a06e2f93f5c1bf98b3fddb126d006c49c33fc59fdef4bf24fae50300eaf46a8986ff62cef66f4bb401f09f2d6df8a75c4ab8501000c0de2aeb57f95be4097f519a1b005bf2f04f39423e2bd1620000d4e1dd72985439fc9de606c0ffbdd8a73ad67259f9a2448b0200b06c7f2c874b73f8db22cff66f4bda002cfa758e965c41be22d1e200002c93df15165ddf7fd127fc45f106a0c6e19f7265f9ba448b0400b02cfe709fcb4873f02ffe6cffb6d43cfc53ae2aa74bb4580000cbe013c0fdcceffaf05ffcd9fe6da97df8a7fc8c7c4ba245030028dbe765fd93fdaa3ae18fec9e6b0b1f230c00cbe273bdae2e0c7fb26b6e226749b488000065394d8e91e6f0b7aacef627bbc72f85f8dd103f25b793b3255a4c008032f865ddeb49dbf0e72570b232fcd302b993b0090080329d213795e6e0aff66c7f12270d7f7f626073a1d82dc58b285a5c008079fa865c5f9afdbceab3fdc9ceec36fc93ebcad7245a64008079f1155eaf29cd3ece097f64259b0cffe46af21989161b00601e3e25bcd58fec99f5d7fcf7e28b479c2cd1a203006cd75fcae564bd7773b63ff949d223ff2ec33ff1b5a34f9468f10100b6e303c2b5fdbb65e99ffabb2343867fe28f8e7c93448b100090d7f1722969f669cef66f8febe1e1efcf01aa2669f86ff29aff5ebcb85e2cd1620400e4f14a3944d6fb3367fbc7690eff6a3600630fffb4b89e20174bb4300100d379beecd69fc96a9ac3dff3b08a0dc054c33fe5217281440b1400302e3fe87ab26cd29fc98134877f351b001fe890d7fc9bdace26bdbbfc50a2c50a0018c785f29bd2a53f937d75f12c3c78ffd7c56f00d223ffb187bf7f6e945b091f220400d3385f1e287dfa73cd715d3cf893c56f00c61cfe7e5a69d3c5751df9ba448b1700d08f3f97e51e32a43fd716d7230dff4beeffbaf80d401afe63bfe6bfe9e23a4a3e2ad122060074f325b9918cd19f6bc9faf0af620330d5f0ef1a17f975122d6600c0664e125f8575ccfebcf43487bf9f1da962033097e1dfcc63c527ad440b1b00d0ee4572a84cd59f9718cf410f760f7c0fff6a36003ea0a9cff6ef93bbc8f7245ae00080557e4795df5e1df5661bb33f2f2d69f87b8354c506203df2cf75b67f9ff8a3294f9568b10300f6f1e7f8df52a2de6c53f4e725243df2777d3cfcabd8008c39fcfdb4d2948bcbd7aafea0448b1e006af717b2fe51beb9fa73c98986ffe23700beaa910f625b67fbf7897ffecb255afc00502b5fd37ffd037d72f7e712d31cfe9e85b6f80d800f7a8ae19f2b0f951f4b744700805af8e23e6d57f6b36df4e752120dffc56f004a1ffe29b791ef4874a70080a5fba6dc41a2de6c0cfff6a439e8faf825f06a3600bee1733cdbbf4ffc7ad7a725ba7300c052fd2fb986447d39d9767f9e739ac3bf8a0d40daf18c3dfcfd73b719ef72df25d19d040096e68d7284447d39994b7f9e5b9acf80a7e1bff80dc098c3df03778e8bebd7e51c89ee300050ba33e54112f5e564aefd790e691bfe7d3700453cbb52e2d9fe7d7315f98844771e0028d507e46a12f5e564eefd799b49c3dff5719d6cc806a0881a37773cd182e9a2b9b8e61c6f781e2fe7497447028052fc401e25514f6e2aa53f6f23d1f0efbb01f0cff153ff550eff924e7a3856fe56a23b1500ccddc9726d897a725389fd39579a73b039fcadcf06a088e1eff8a07d60d182e9cac5287167e91a3c4b2e90e80e060073e3672f9f2ad107f9444aedcf39d236fcfb6c008a7ae43ff6f02f62d7d3929bca1724bab301c05c9c22ee57512f8e2ca13f4f913407db86bf75d90078f8fbe5e55967cce1ef022d6971f9585e26174b74c703806df1c79ebf400e97a81faf5b5a7f1e339b0c7fdb6403e0e1ef9f55ccf0f701440ba60b1767a98bcb57cefaba44774200c8ed4b727b897a7164c9fd7968a239d81cfa4d9b6c00aa1dfe4b3ea1c4afadbd41a23b2300e4e06723fd213e4749d48b2335f4e7be699b83cda1dfb4db06c0c3df27fd31fc179c7bc91912dd3901602aff20f790a80fb7a9ad3f77c96e73b039f49b76db001431fc1d1fb40f60fda0fbf081fb69a59a72a4bc5ba23b29008ced78b9a2443d783735f6e74db3db1c8c86bfb56d008a7ae43ff6f0f7cfad310f96b324bac302c050df95bd2ee5dba6f6fedc964de66034fc2dda005437fc5d08bfdec1e2daf76cc01f88cfc88deec000d0d58fe515d2e7513ffdb93d9bcec1e6d06f5adf00a4e13feb3aa783f60d8e0eb60b17819de5ce5c47fe4ca23b33006cea8fe50612f5dfbdd09fdbd3650e36877e5373f8fbed7e559ef0e7c5455693ea7c1ff98a44776c0068f379b9a744bd7713f4e7f6749d83cda1dfd41cfeb3af33c33f4fd6eb7c69f16539cf96e88e0e00893fb2d71f467698acf7dd4dd19fdbd3670e36877e933700450c7fc707ed1b1c1d6057e93525b2336d75fe69799d5c24d11d1f40bdd2ebfc5792f5ded115fdb93d7de66034fcada847fe3e68dfe8e800bbe0849238cd3a47754b6e2e1f91a80900a8cffbe5fa12f58baee8cf7136edcf91f5c16fc53dedef1b1d1ddca6fcfd2cae387d16d7fde4ab12350400cbf739b99bf4194aebe8cfed1932fc2d0d7df3cf28a2cee9a0c77ecd9fc5b59a2175f6f9014f13ce0f00eae1d7f91f2deea9f4e76933c61c64f88b0f9aac66ac3afbfc80d70be70700cb7581f81345fd897df4e7e933567f5e1ffeb30ec33f4fa6a8b3dfeffb21899a078072f975fe6b0afd394fc6ae7311c3df4907ed1b1d1d4c17c51cf416e23a8ff1da9dadd7d91f32f409891a0980729c2c3f272953f60d7220d5d5b9b9e3f1f04fa203da443a68ff5c7220a9ce632faea8ce7712ae280894e744b9b5a4e4ec1b3567aa3acf3ae9a0d7877f9f0d80bf87c515a7b9b8fad4b6a94b9d6f22ef147ffe77d46c006c9f3f03e4ad723d69665b7da3b65459e774d07e2dc8373a121d60c4ff96c515c7d7794e9baca8765df4adb35f43f4c5847cd190a80101c8ef47f23fc427f3ae670e7da3865459e74d86bf4507b9ceff2e1d34594daaf3d88bab6ffca9602f961f48d490004cef7bf25cb98c44995bdf586aaaacb30ffa12e2e1efa73cd2d31ebb890ed8fc772cae38735e5c7e3bd1ef883f273c6a5000c6f72d79a21c226d61f8e749b5755e1ffe9b6c0092f5036771b567acc56553d5d9bffbff4fbe2151c302309c3fd9f3e1e2fbf15e29a16f2c21d5d5393df2f78df5813737005d3601493a68ff5c7220cd9d6554b7ae72d4d9b7f721e28f128d1a1880ee4e91fbca26c3a1c4be5162a6aaf3ace3836e0effa11b0016579cd2efc4fefff1b504fe5aa28606606ffed0aebbcaa629bd6f94922aebec1be71be94f214ac3dfd637009b6c02fc6f585c71d2e2daebc4ca4dcca1ceb793b7c80f256a72000e38477c596e7f6a67972cad6fcc3555d6d9372e0d7f1fb8edb509b0bd0e9aac66aac535871c2a0f155f992c6a7c40ad7c7d0d5f82fbc1e2fb6dd72cb96fcc29d5d6d937f26049c3df9a1b80dd360156e441674e4d8beb1a729c70d2206ae693fa9e21474bdf30fcf3a4fae1ef1b6c6903605d3601c6e26a4f7a5745b460ba2aa5cebe78862f37cc4b04a8853f7afbb5721bf150199a1afbc63652659dd3f0f753ffbed19686bfad6f0076db04f867b0b876c64d202daea86e5da53a8fd15c72c6ef69fe75f9a8448d1328959fe2f7676a3c48dc23c7087d234faaacb36f5cbab4a16fb0a50dc0269b004b07ecff6671c51973712da9ce5797670b2f11a0645f92a7c9bf973143dfc8932aebec1b97867f7af49fb46d02cc07b8ce7f9e0e9aac262d2ed7325a305db8d64bacb3d7e11de5cdc24b0428c1f7e5d5722b9922f48d3ca9b6ce6eba3e700fffc4373e491b005bdf0418c37fef341757aa575fb5d439bd44e0b3a52f90a8f902db709e7c401e20be3f4e15fa469e545be734fcfde83f3d03b0db06c07c80117f1f8b6b67b8130f8fdf52f81fe53572ba444d1998d257e515f20be2fbe2d4a16fe449b575f681fb86a6e1dfdc00ac6f022c6d009234f8cdffde9b09b233632d2ea3cefbe2cf3f7f92f8ca693c3b8029f851fe9fc863c51f8b9d3bf48d3ca9b2ce69f8fbe0adef26c0fc3d2cae9d493b4bd7adb959ea8b3b719cc3e43ef206f947899a39b089af893f67ffeee2d772b711fa469e545be734fc9b1b00db7413601efcfecaf08f936a9c6a152d984df9fbb913c789ea7c5379bafca5f0ec0076e347f91f946d3dca5f0f7d234faaaeb36fa80fde9a1b80dd3601e6623531fce3a4c5e59a79710c419ddbb3499d2f23f7139e1d40328747f951e81b79527d9d9b1b00ebb20948fcef585c3bc39d384ffad6d9cf0e3c55de2ba7493420b02cbefceef1e247f9c7c81c43dfc813eaacac6f006cb74d80b96009c3bf3d697179710c55e4e2ca94b1ea7c05f12341bf64f01e615350363fba7f87f804515f4fe2525242e81b79429d15df6873319a36d904f8cfbd8b223b33e6e2729db913c799bace7ed9e0e7c51fdae2670a78dbe13c7d5dde294f913bcba5a5c4d037f2843aef8f6f78e2a234f9c09a9a1b00ff3dc33f8e6b99364943b9eed439ceb6ea7c59f1fbbf7f47fe48389f202f3f33f36ef16576ef2247ca1242dfc813eadc888bd1b4d726c018fe715c93b116977f866b4d9d77668e75bebcf8e58367cabbe493f25d89061836f36df9849c207e06c6cfc41c254b0b7d234fa873101764ddfa26c07cb0e6ff6671ed4c5a5cae9117c750d4394e6975f699e53ed9cc8f541f26c7c99be42fe4efa5d6b726fe587c353d5fdaf9ff97df135fead94fdfff8cf82d553584be9127d4b9252e4ac407b8ce7fcee2da993117977f866b4d9d77668975f66db892f8c363ee2f4f96df97f7cbe7e41c8906e8dc7d4f3e23ef13bfcdee89725fb9b9f8644bff1e6b0f7d234fa8f32e49c569e38335ff378b2b4eaa9317c750dc89db536b9d0f976bc94de4b67257f16721f8f3e57f431e277e3dfc39f2527995f81314fd52c449f297f2b7f277e293e5be23fe74c58be4dcfdffdb7ffe79f153ee7e76c2dfe7d7d9df22fe74bb97c973c5ef9078bc3c5c1e2cbf247793dbcbcde458f1097825d63977e81b79429dc31c74d0ff058092ac6f81d0c12a0000000049454e44ae426082);
INSERT INTO `users_information` (`UsersInformationID`, `UsersID`, `FirstName`, `LastName`, `MiddleName`, `BirthDay`, `Age`, `Address`, `Contact`, `Sex`, `Image`) VALUES
(2, '2', 'Cashier', 'Cashier', 'Cashier', '1998-08-31 00:00:00', 21, 'Malabon City', '09777712398', 'Female', 0x89504e470d0a1a0a0000000d4948445200000200000002000806000000f478d4fa0000000467414d410000b18f0bfc6105000000206348524d00007a26000080840000fa00000080e8000075300000ea6000003a98000017709cba513c000000097048597300000f6100000f6101a83fa7690000001974455874536f667477617265007777772e696e6b73636170652e6f72679bee3c1a00004a9f49444154785eeddd07bc6c5779df7dbd798948e2441242123d08538c10bd865e0c188c694e4ca806173098f28662d3b1c188167a426c3a2f5d46b41881656c0336c2d8c1a0d00ca219641904c8020981844af2fffbdec5dd33e7d9e7cc6e6bf6daebf7ff7cbe9f23eebde730fb396b9e67cdcc9e3d072d30ff42fe5fb9c408fc73fe1f213b439df364af3aff6b3956ee290f9147c993e539f2dfe40d72829c241f934fcbd7e4bb72fe7efe6fff99ffceffc6ffd6dff37a79b91c274f9247ca2f8bffbfae2d9794a584f59c27d4394f5c17d77a378bab9d0fca0be35f0ec4e2da3dd4394f9a75be9cdc561e262f94f7c9a97281fc9f2db948be2227ca8bc5b7cdb7f132525258cf79429df3c47571ad5da3c4ff3bb298f860c6585cc6e26a0f759e3697967bc813c58fdefd88fc4c8906f09c9d251f171f839f91b8b7cc7163c07ace13ea9c27ae8beb13f1ef60dd22e203f1c23878045ea42cae38d479fc1c22bf207e047d8a5c2cd1405d8acf8a5f56b8971c26db0ceb394fa8739eb8ce1ef4ae51b2d726a0e8a4ddce988babf8a24c10ea3c5efc9afd1dc5afd1fb11f285120dca1af825844fc80be42ef2539223ace73ca1ce79e23abb2eae4fc4bf8326ffdba4d83417974f461a82c5d51eea3c2caedb2de5e9f221394fa26188830efab17c549e253e97c06b66ecb09ef3843ae74973f8bbd689ff77937f174dfe9e62eb9916971746b460ba72c1585c3b439dfbe716f207e2d7c2a36187bd9d2daf93db89d7e2d0b09ef3843ae789ebecbab83eaeb5bf366db209282ecdc5f5af066271b5873a77cfd1e247fa3e3b3f1a68e8cf6f53f4330357973e613de70975ce17d7d9f571ad9bfc67c96e9b8022ebea1bee85112d98ae585ceda1ce9be5dfc9afc88765e927f0cdc5c9f21bd2e52442d6739e50e73c719d3dec5d6bebbb092826de59fac6a7c5e593a9867091585c3b439df78e8fe74ef2663957a22185e9f97c8a3f94bb89d76c14d6739e50e73c693ec3e25aaff39f276d9b80e2360069718db1b02c2d2eff5c7220d479f75c567cf6fe3f483490b03ddf9217c9952485f59c27d4394f5c0f0f6d0f7ad73ae9bb092862839516970fcc8be3df0cd05c5c6435d4b93d579657c88f241a3e980fbf93e035e2730558cfd387be9127eb756e6e00fa6c025c63ffcc59271db40f305a305db8682e4c314f7b640c758e730df159e81e2ad1b0c17cf9fa0ac7cb8d255aa79ba26fb487be9127ebc3bf296d0012ff9ba46d03e01a5735fc8dc515873aefcc75e5ede20bd544c305e5f089997f24b79668bdee85be1187be9127eb755edf00ac6f025cc7247a16a088e1eff8a07d70be3ad8502caef650e703b999fc4fe16cfe65fa53b9b3446b3742df680f7d234fda365969f8279b6c028a18fe69c7c3e29a36d4f9407ca1990f4a3434b03cfe80257f1641b48e13fa461cfa469e34ebbc3efc9bfcf749b40948c3df3fabbae1ef4214b1ebc91ceabc2f7e8d9fc15fafbf929bca52d6f3d4a16fe4c96e75de7413d0dc001433fcfd1a850fe2df0ec4e26a0f75de779b7d5539aecb8f0bc49f4ee88f2aa66fb487be9127aec75e9bac4d3600e60d807f67b37f57c5548b8bac863a1f74d05de52b120d03d4eb74b9bfd0377686be9127eb754e033fb2d72680e14f56527b9daf28ef94a8f903c949723521fb427fce93ddea9c86febadd3600450c7fc737d407b07ed07db0b8da536b9dfd74da13e41c891a3eb0ce2f0d3d53bcce6b0ffd394f36a9f3a69b00bfee5fcc23ffb117977f2e39909aeb7c2bf98c444d1ed8cb97c52f19d518fa739e74adf35e1b00863ff9496aadf3e1e22bf8f17e7e8cc12f1d5d416a09fd394ffad4797d03903601c50e7f7f9c6a5ffe7e16579c669da3da7551529d6f29df90a891037d7d476a7836a0d6be913bcd3aa739e8af9b58df0078f8fba4bfa286fffa62e9ca85488b8baca6c63afb989f287e5b57d4c081a1fc8cd2f3c4e7952c31f4e73cd9abce69d0b7690e7fff0c0fffd9d799c5952735d6f908f980444d1b18db47c5ef2a5952e8cf79d2a5ce69e0478a1afece588bcb585ced719dbd38a2ba7555429dfd212f7c3e3f72fbaefcbc2c25b5f58d6da54b9da3c19ff86714f7c8df373c3ad02ed2e2f2cf250792eaec8551439d7dbb9e22fed8d7a8410353f34b02cf97925f12a8ad6f6c2b7debec7f1ba96ef8fbfb595c719a8b2baa5d1725d4f928f1055ba2a60ce4e69704ae24a5a5b6beb1ad0ca9b3ebdae49f51449dd3418ff1b43f8bab3db5d5d99fdcf78f123562605bfc92c0dda494d09ff3648c3a573ffcfd36071f34594d6d75fe6de1297fcc955f1278b6cc3df4e73c19abceebc37fd66171e5494d75f6b1be4ca2a60bcccdeb65aee705d09ff364ec3a1731fc9d74d0bed1d1c17451cc416f21aef318afddd99cebecab5bbd4da2460bccd51f8987e3dc524bdfd876aaab7373c7e3e13f7403900eda3f971c48aaf3d88b6b8e75f61afaa0440d1698bb93c597a59e436aea1bdbcc54759e75d24137877fdf0d80bf8fc51567ccc535f73a1f299f90a8b102a5f89c6cfba24135f58d6da6ca3aa783f6d35dbed14dd181edc6df935e536271adc6d7794e9baca8765dccbdce579153256aa84069fcd914c7c8365253dfd866c6ae73f1c3dfa2836be37f9f1617594daaf3d877e239e67ac2dbfcb03467ca7f909ca9a96f6c3363d7390dff59c707ed335ddb86bf450718f1bf6571c5a9e94e7c5bf99e440d1428ddb992ebf2c10cff3ca972f83b69f8fbf50edff048749091620e7a0bf1e2aae184925f94f3246a9cc052f8d32a7f59a64e2d7d63dba9aececd47fe3ef0a11b8074d0feb9e440d2ce72ecc535c73adf4bb8c00f6ae10b064db509a8a96f6c3355d6d937cec3df37d64f790cd900f8ef595c71c65c5c73afb33fcdef4712354a60a9fc4cc05d65ccd4d437b6992aebec1b170d7ff34144a20336ff5d7a4d89c5b59ab4b8c67eed6e8e75be8e9c2551830496cee7048c7562604d7d639ba9b2cebe711efefe08421ff8900d80ff3c1d3459cd548b6b8e395a4e97a83102b5f087080d7d8b604d7d639ba9b2ce3e68dfc8e6f0b73e1b00ff990fda9b09b29a2916d75ceb7c847c51a28608d4c6d709e87bb1a09afac636536d9dd3f0f70d4ec3dffa6c00fc33d859c6f1e2722dd76bd6c79cebec75f137123542a0569f954b49d7d4d237b69d2aeb9c86bf5ff71fba01e0849238696739f6e29a639d7d9c2749d40081daf9b3037cffdd2435f58d6da6ca3afbc6f946fa93d8d2f0b73e1b007f6571c5197371cdbdcebe4d6f91a8f101d8c79f22b8d753c335f58d6da6ca3afbc63587ff900d80b1b8e2a4c5e55a460ba68b12eafc12891a1e8055af93b6d4d637b6952aebec1b973ed4203df5df7703e03ff7f77242c9ce4cb1b8e65ce7c749d4e800c49e25eba9ad6f6c2bd5d6b939fc876e00fc7ddef190d5d4b6b86e29bee849d4e400c47cb5c0e6858218fe7952fdf0f753ff4337000cfff6b8c6ae59b460ba9a7b9d2f2da749d4e000ecee3b7205716aea1bdb4c9575f6f0f72ec5c37fe806201db47752e440d2ce72ecc535d73afb769d28516303b099bf14f7de5afac6b6525b7ffe49d2f0f7c10fd900f82b8b2bce988bab944dd613256a6800ba79a144bda00b1e9cb5a7c6fefc93f886fae0876c008cc515272d2ed72c5a305d7871f9f730f73af3ba3f301e9f0f706f897ac2264ae91bdb488dfd7925e9d17fdf0d80ff3b0d7fb29aa916d79cc3ebfec0f8fc99013f23516fd84d297d631ba9b13fefc8900d80bffadfb1b876a6c6c5e563e6757f601abe52e06112f58808c3bf3d0cfffd19b20160f8b7c7f5748da205d35529cfb0fcb6448d0bc038ba9c0f504adfd8466aeccf61fa6e0018fe71d2ce72ecc5e59f3be7dc4278dd1f9896cf07b89744bda2a994be913bb5f6e7d674dd00f86b1afe2caed58cb9b8fcb452298bcb9f62e68f348d1a168071f9fa005797d2fb46eed4da9f774d970d401afe7eeb20594d5a5cde24450ba68be66b4a252cae574ad4a8004ce39d527adfc8999afbf3aed97403e0affe3b1f3459cd548bab84dc4cfcb464d4a4004ce79e526adfc8999afbf39ed9640390863f8ffc77a6e6c5e5dbf949899a1380697d598e10867f7b18fe7b64930d00c3bf3dae5bad67933e46a2c604208fe3a4b4be913335f7e78db2d706c07fcef0df99b4b3acf56cd2cbcaf7256a4a00f2f891f884c052fa46aed4de9f37ce6e1b00867f9c3117979f562a7171bd55a2860420aff70b3910fa7387441b0063f8c7498babe6b349ef20512302b01dbf2884fedc39d106c07fc6f0df99a9165749f1faf882444d08c076f83a1c7ec45b73e8cf3dd2dc0018c33f0e8b6b5f9e22510302b05d2f905a437fee99e606c0ffbdd8a73a06c6f519fb8492d272b4fc50a2e60360bb7c29ee63a5c6d09f7b266d007cc00cff9d493bcbb1175789b57eaf448d07c03c7c586a0afd7960bc0160f8c7197371f969a59217d78d256a3800e6e58e5243e8cf2384e11f272d2ece26dd97774bd46c00cc4b0dcf02d09f470ac37f67a65a5ca5c6af2b72bd7fa01cb792a586fe4c260b8b6b67de22519301304f7f2c4b0cfd994c1a2f2ece263d90abc98512351900f3e5f3769616fa3399246967c9d9a4ab79b544cd05c0bcf9bc9da584fe4c26cb988bcb4f2b2d65715d497e2c517301306f3e6fe73a527ae8cf64b2a4c5c5d9a43bf372891a0b8032bc4d4a0efd994c96a916d712729470d53fa06c17c935a4c4d09fc9646171ed9ee749d4500094e5f5525ae8cf64d278717136699c4bc9d91235130065f16704f8733c4a0afd994c92b4b3e46cd2f63c49a24602a04c2f9512427fce97ea3ef577ccc5e5a79596bab8fe4ea22602a04cdf167feecb9c437fce13d7c3c37feeeb61d4a4c5c5d9a4bbe7a61235100065bbbbcc35f4e73c690eff6a3600532dae25e61512350f00657b87cc31f4e73c690e7fd7bb8a0d008b6bf31c2c674ad43c0094ed3c394ce614fa73be34877f351b001f2867936e965f94a87100588687c99c427fce13d7c5b5f683bc2a36006967c9d9a49be73d12350d00cbf0519943e8cff9e2ba78f0278bdf008cb9b8fcb4520d8beb08e1baffc0f25d55b619fa739eb81e69f85f72ffd7c56f00d2e2e26cd26e79b444cd02c0b2fcae6c2bf4e73c591ffe556c00a65a5c35e41312350b00cbf215d946e8cf79d21cfe7e76a48a0d008bab7f8e95a8510058a65b49ced09ff3c475f660f7c0f7f0af6603e003e26cd27e79be444d02c032bd4a7286fe9c2769f87b8354c50620ed2c399bb47f4e93a8490058a6b324c700a03fe7497ae4effa78f857b101187371f969a51a17d7b5246a100096ed163265e8cf79120dffc56f007c55231f0467930ecba3246a0e0096ed693255e8cf79d21cfeaeb52d7e03e0839e6271d5987749d41c002cdb9fcb14a13fe74934fc17bf0160718d17efd2b9f63f50a71f8907c498a13fe749aab3ebe39758aad900f8868f7d4249adb9a1448d01401dee206386fe9c27cde15fc50620ed78c65e5cfeb9b5e609123505007578b68c11fa739ea43a7bd0a7e1bff80dc0988bcb4f2bb1b8f6e5fd1235050075f8980c0dfd394fda86bff5d90014f1ec0a67934e13effece91a82900a8c305e2bed837f4e73c49c3dff5719d6cc806a0881a37773cd182e9a2b9b8c8bef700470d01405d7e5efa84fe9c27d1f0efbb01f0cff183bf2a877f91673d4e14bf07386a0600eaf242e91afa739e34ebdc1cfed6670350c4f0777cd03eb068c174e562b0b35c8ddf031c35030075f9a4740dfd394fda867f9f0d40518ffcc75e5c45ec7a32c58be23c899a0180ba5c2487cb26a13fe749aa73dbf0b72e1b000f7f9faf31eb8cb9b85c2016579c5b4ad40800d46993f300e8cf79b2c9f0b74d36001efefe59c50c7f1f40b460ba7071585c715c8f874ad40400d4e971b25be8cf7912d5b939f49b36d900543bfc39a16467529d5f2251130050a757495be8cf79d256e7e6d06fda6d03e0e1ef93fe18fee49fd3acf3891235010075fa8844a13fe7c96e756e0efda6dd3600450c7fc707ed03583fe83e7ce07e5a89ec4cb3ce5f92a80900a8d3191285fe9c27bbd5391afee67f9f343700453df21f7b71f9e7920359afb3cff6f5d5bfa22600a05e87490afd394f36a97334fccddf93543bfc5d08bfdec1e2da99a8ce3792e8ce0fa06eff411cfa739e6c5ae7e6d06ff2f725cde13feb3aa783f60d8e0eb60b17819d659cb63adf57a23b3f80ba3d58e8cf79d2a5cecda1dfd41cfe7ebb5f9527fc797191d5ec56e7674874e70750b7e70afd79fa749d83cda1dfd41cfeb3af33c33f4ff6aaf39b24baf303a8db7b84fe3c6dfaccc1e6d06ff206a088e1eff8a07d83a303ec2abda6447666af3affb544777e0075fb82443da32bfa737bfaccc168f85b518ffc7dd0bed1d10176c10925719a758eea96fc9344777e00753b5ffc4e80a86f6c8afe1c67d3fe1c591ffc56dcd3febed1d1c16dcadfcfe28ab3e9e2ba8a44777c00b0eb4bd43bf6427f6ecf90e16f69e89b7f4611754e073df66b4a2caed574a9f3ed25bad30380dd4ba2deb11bfa737bc698830c7ff14193d574adf33d25bad30380f9ad8051ef68437f6ecf5873707df8cf3a0cff3ce953e7074a74a707007ba444bd23427f6ecfd873b088e1efa483f68d8e0ea68b620e7a0b719dbbbea6f47089eef400604f94a87744e8cfede9d39fdb14f7c8dfc37fe806201db47f2e399054e73e8beb0912dde901c09e2d51ef58477f8e33a43f478a1dfe7d3700fe3e16579ca18beb9912dde901c05e2a51ef48e8cfed1973f81753e774d07e2d280dfe243ab0ddf87bd26b4a2caed5f83acf699315d56e132f92e84e0f00f61a897a87d19fdb33467f4e5ce7e287bf4507d7c6ff9e134ae2a43a0f5d5caf94e84e0f0076bc44bd83fedc9eb1fab3b9cec53ced7f09691bfe161d60c4ff96c51567ccc5f51689eef4006027ca7adfa03fb7a7cae1efa4e1efd73bd2c05f171d64a49883de42bcb8c63aa1e4bd12dde901c03e22eb7d83fedc9e31fb73718ffc7de0433700e9a0fd73c981a49de5988beb4f25bad303807d52d6fb06fd7967a6e8cfb3afb36f9c87bf6fac9ff218b201f0dfb3b8e28cb9b89a75feb844777a00b05365bd6fd09f5733557f9e759d7de3a2e1df6703e0bf4baf29b1b8569316d758af2935ebfc3989eef40060ff28f4e7f64cd99f671bdf380f7f7f04a10f7cc806c07f9e0e9aac66aac595f20d89eef40060e708fd39ced4fd7996f141fb4636877fdf0d80ffcc07edcd0459cd148b6bbdce7f2fd19d1e00ecfb427fde991cfd799649c3df3778e806a0881dcf96e2c5e55aaed7ac8fb63a7f46a23b3d00d869427626477f9e5dd2f0f7ebfe4337009c501227ed2cc75e5c519d3f26d19d1e00ecf3420e24677f9e4d7ce37c230f9634fcfb6e00fcb58883de42c65c5c9bd4f92489eef400607f2d645f72f7e759c437ae39fc876c008ce11f272d2ed7325a305d6c5ae71324bad30380f95a21643bfd79ebf18d4b1f6a909efaefbb01f09ffb7b39a16467a6585c9bd4f9f512dde901c0de2db5675bfd79eb690effa11b007f9f773c6435db5c5c2f97e84e0f00f646a939d50f7f3ff53f7403c0f06f8f6bec9a450ba6abae753e4ea23b3d00d82ba4e66cb33f6f2d1efedea578f80fdd00a483f64e8a1c48da598ebdb8bad4f94912dde901c09e2735660efd792b49c33f3dfaefbb01f057867f9c3117d7904dd62325bad303803d556acb5cfaf356e21bea831fb20130867f9cb4b85cb368c174e1c5e5df43df3affb244777a00b0c7484d99537fde4ad2a3ffbe1b00ff771afe6435532daebeb9b744777a00b05f915a32b7febc950cd900f8abff1dc37f67e6b8b8ee28d19d1e00ec3f490d61f8efcf900d00c3bf3daea76b142d98aec67a86e54612dde901c07e566ac81cfbf356d27703c0f08f937696632f2effdca13954a23b3d00d89565c999737fde4aba6e00fc350dff620f7aa28cb9b8fcb4d2148beb9b12ddf101d4ed87b2e49e5e427fce9e2e1b8034fcfdd641b29ab4b8bc498a164c17cdd794c65e5c1f96e8ce0fa06ea7c852534a7fce9e4d3700feeabff34193d54cb5b8a6c82b25baf303a8dbf1b2c494d49fb367930d401afe3cf2df99d216d76325baf303a8db33656961f8ef914d36000cfff6b86e259d4dfaf312ddf901d4edfeb2b494d69fb367af0d80ff9ce1bf33696759dad9a43f2dd19d1f40dd6e284b49a9fd397b76db0030fce38cb9b8fcb452cec5e5dfe77912350000f5722f5a424aeecfd9136d008ce11f272dae92cf26fd8c440d00409d4e93256409fd396ba20d80ff8ce1bf33532daedc3941a22600a04e7f2aa56729fd396b9a1b0063f8c759d2e23a4ea22600a04eaf9092c3f0ef99e606c0ffbdd8a73a06c6f559cad9a40f92a80900a8d3a3a5e42ca93f674dda00f88019fe3b9376964b3a9bf4c61235010075f22785969825f6e7acf10680e11f67ccc5e5a795e6b2b8fc3b3f47a24600a02e1788fb5369596a7fce1a867f9cb4b8967a36e9fb256a0600eaf231292d4befcfd9c2f0df99a916d79cf204899a0180ba3c5b4a4a0dfd996c29b52c2e5ff52b6a0600ea720729250c7f3269bcb86a389bd46ff53c53a28600a00e3f12f7a952524b7f2699937696359d4dfa2e899a02803afcb994901afb33c9943117979f562a65713d4aa2a600a00e4f93b9a7d6fe4c32242dae1acf263d46a2a600a00e379739a7e6fe4c26ce548baba47c53a2c60060d97c2d105f1364aea13f93c9c2e2da97b748d41c002cdb8932d7d09fc9a4f1e2e26cd2830efa35899a0380657bbccc35f4673249d2ce92b349f7e52a12350700cb7603995be8cff952dda7fe8eb9b8fcb4d25216d7a912350800cbf42d99db00a03fe789ebe1dffd9ccfff183d69717136e9ce3c5da2260160995e2c730afd394f9ac3bf9a0dc0548b6b29395a2e96a85100589eebcb5c427fce93e6f077bdabd800b0b836cb87256a140096e5d33297d09ff3a539fcabd900f840399b74effcaa44cd02c0b2f89340e712fa739eb82eaef5c1fbbf2e7e039076969c4dba597c8ce74ad430002cc3857279d976e8cff9e2ba78f0278bdf008cb9b8fcb4522d8b8b8b0201cb76926c3bf4e73c713dd2f0bfe4feaf8bdf00a4c5c5d9a4dd7367899a06806578806c33f4e73c591ffe556c00a65a5cb5c427899c2e51e30050b6b3c5bd715ba13fe74973f8fbd9912a36002cae71f27c899a0780b2bd5eb615fa739eb8ce1eec1ef81efed56c007c409c4d3a3cc74ad43c0094edf6b2add09ff3240d7f6f90aad800a49d2567938e974f48d4400094e9ebb28d9e467fce13d7c303ddf5f1f0af620330e6e2f2d34a2cae7d79a4444d0440999e25b9437fce9368f82f7e03e013d67c1063bfa6c4e2da57d36f4bd4480094c5d7f738527286fe9c27cde1ef5adbe237003ee82916173990274bd44c0094e5259233f4e73c8986ffe237002cae3c3954ce92a8a10028c3797205c915fa739ea43abb3e7e89a59a0d806ff8d82794909d719d9f2b51530150863f909ca13fe789eb9c867f151b80b4e3197b71f9e7920369d6f9cac2e7030065ba40fc51df39427fce9354670ffa34fc6dd11b803117979f566271c589eafc72899a0b80797b83e408fd394f529dd787bff5d90014f1ec0a6793e6495b9daf2e7e1d316a3000e6e922f919993af4e73c49c3dff5719d6cc806a0881a37773cd182e9a2b9b8c86af6aaf3ab256a3200e6e9ed3275e8cf79120dffbe1b00ff1c3ff55fe5f02ff2acc789b3499daf257e3d316a3400e6e562b9ae4c19fa739e34ebdc1cfed6670350c4f0777cd03eb068c174e562b0b38cb3699ddf2c51b301302fef95a9437fce93b6e1df670350d423ffb1175711bb9e8ce95ae71b8a5f578c1a0e80f9b8894c15fa739ea43ab70d7f4bc3dff6da0078f8fb7c8d5967ccc5e502b1b8e2f4adf39b246a3800e6e15d3255e8cf7992eabcdbf0b734fcad6d03e0e1ef9f55ccf0f701440ba60b1787c51567489dfd9ee27f92a8f100d8ae1fc895648ad09ff324aa7373e8376db201a876f87342c9ce8c51e7c748d47c006cd76fcb14a13fe7495b9d9b43bf69b70d8087bf4ffa63f8937fce58753e44fe46a20604603b3e2bbe7f8f1dfa739eec56e7e6d06fda6d0350c4f0777cd03e80f583eec307eea795c8ce8c59e79bc98512352200f9dd5aa608fd394f76ab7334fccdff3e696e008a7ae43ff6e2f2cf250732559d5f2a51230290d71497fca53fe7c926758e86bff97b926a87bf0be1d73b585c3b33659dfd67a74bd49000e4e193728f9431437fce934deb9c06fe3a7f5fd21cfeb3ae733a68dfe0e860bb7011d859c6c951e7ff2c51530290c76fc898a13fe749973aa781bfae39fcfd76bf2a4ff8f3e222abc959e73f91a8310198d6c765cca64f7fce93ae754e037f5d73f8cfbece2cae3cc95d673e2d10c8cf27e1de40c60afd394ffad4390dfc75de001431fc1d1fb46f7074805da5d794c8ce6ca3cecf94a8490198c6cb64ccd09ff3a44f9da3e16f453df2f741fb464707d8052794c469d639aa5b575deaec85788a448d0ac0b84e15df47c7c836fb464d1952e7f5c16fc53dedef1b1d1ddca6fcfd2cae3863de89fbd6f91a72b6440d0bc038fc72dbf5658ccca16fd490a175766d13ff8c22ea9c0e7aecd794585cab99539def2751d302308e47c818a13fe7c9187566f88b0f9aac668e757e95448d0bc0307f286384fe9c2763d5797df8cf3a2cae3c996b9dfd733e2d510303d0cf97c59fc33134f4e73c19bbce450c7f271db46f7474305d1473d05b88eb3cc66b7736769daf29fe68d2a89101e8e67cb9918c9139f78d25a5ba3a37773c1efe433700e9a0fd73c981a43a8fbdb8c6aef303256a6600ba79940c4d297da3f44c55e759271d7473f8f7dd00f8fb585c71c65c5c39eafc5a891a1a80cdbc5386a6b4be516aaaac733a68bf16e41bdd141dd86efc3de9352516d76a7cc9cfb4c98a6ad745ae3afbb6fa73caa3c60660775f954365484aec1b2566ec3a173ffc2d3ab836fef7697191d5a43a8f7d27ce916bc9b91235380031bfee7f13199292fb464919bbce69f8cf3a3ee84b48dbf0b7e80023feb72cae384bb813fbfa00174bd4e800ecf4701912867f9e5439fc9d34fcfd7a876f78243ac8483107bd8578712de18492c749d4e800ac7a960ccd52fac6dc535d9d9b8ffc7de0433700e9a0fd73c981a49de5d88b6b9b757e81440d0fc03eaf94215962df9863aaacb36f9c87bf6fac9ff218b201f0dfb3b8e28cb9b8e65467ffffbf41a2c607d4ee5de2fb69df2cb56fcc2d55d6d9372e1afee6838844076cfebbf49a128b6b3569718dfddadd5ceaec3574a2440d10a8d547c4bdb56f96de37e6922aebec1be7c6ed8f20f4810fd900f8cfd34193d54cb5b8e6161fdfc7246a84406dfeb70c79bb5f2d7d63dba9b2ce3e68dfc8e6f0b73e1b00ff990fda9b09b29a2916d79ceb7cb87c5ea28608d4e26b7239e99bdafac6b6526d9dd3f0f70d4ec3dffa6c00fc33d859c6f1e2722dd76bd6472975be929c2651630496eedb727519921afbc63652659dd3f0f76b534337009c501227ed2cc75e5ca5d4d9170a3a53a206092cd5397263e99bdafb46ae545967df38dfc883250dffbe1b007f6571c5197371955ce79b0b570b442d7c95bf3b49dfd037f2a4ca3afbc63587ff900d80b1b8e2a4c5e55a460ba68b25d4d99b009e09c0d29d2d7794bea16fe4499575f68d4b1f6a909efaefbb01f09ffb7b39a16467a6585c4ba8f331f20d891a2750ba3364c8e7fad337f2a4da3a3787ffd00d80bfcf3b1eb21aeec4bbe78af239891a28502a7fb2dfd5a46fe81b7952fdf0f753ff4337000cfff6b8c6ae59b460ba5a6a9dfd1641ae1380a538452e2b4342dfc8932aebece1ef5d8a87ffd00d403a68efa4c881a49de5d88b6ba975f61a7b9f440d1528c587e410e91bfa469e545be734fc7df0433600fecae28a33e6e2aa6993e575c96707a0542788fb68dfd037f2a4ea3afb86fae0876c008cc515272d2ed72c5a305d7871f9f7505b9d9f2f518305e6eaf7c50faefa86be9127d5d7393dfaefbb01f07fa7e14f5633d5e2aa318f958b256ab6c09cfcae0c097d234fa8b3326403e0affe772cae9d61718d9ffbca0f246abac0b69d27bf2e4342dfc813eabc3f4336000cfff6b89eae51b460bae2199603b9a67c46a2060c6ccb97e4063234f48d3ca1cefbd37703c0f08f937696632f2eff5cb22f5e8baf96a81103b91d2f43cef477e81b79429dd7d27503e0af69f8b3b85633e6e2f2d34adc89e3a43affaaf09200b6c54ff93f428686be9127d43948970d401afe43ce6e5d6ad2e2f226295a305d345f53e24ebc9af53afb69d74f4bd4a081a9f829ffebcbd0d037f2843ab764d30d80bffaef7cd06435532d2eb29ab63a1f29af95a85103637bbb78dd0d0d7d234fa8f32ed9640390863f8ffc7786c595279bd4f921e2cf598f9a3630d48fe4e13246e81b79429df7c8261b00867f7b5cb7b14f28213bb3699daf27bef67ad4c081be4e95319ef24fa16fe40975de237b6d00fce70cff9d493bcbb117977f2e39903e753e428e133f628b9a39b0a90be445e2477f6384be9127d479c3ecb601f09f31fc7766ccc5e5c6c29d38ced03a5f573e28516307f6f251b98e8c15fa469e50e70e893600e6ffcdf0df99b4b8c67e4d893bf16ac6acf303e574899a3cb0ee3bf22b32e67d92be9127d4b963a20d80ff8ce1bf33532d2eb29a29ea7ca8f8a95c3fa51b357dc09f35f14a395cc60c7d234fa8738f343700c6f08fc3e2ca93a9ebec97054e966800a05e9f949bc9d8a16fe40975ee99e606c0ffed42929d717dc63ea184ec4c8e3a7b8dfb2a82df956818a01edf9747cb54f747fa469e50e79e491b001f30c37f67d2ce72ecc545ad57b38d3a5f5afc9902174a341cb05c7ebaffcd72599922f48d3ca1ce03e30d000b2bce988bcb4f2b71278eb3ed3a5f55bc11385fa26181e5f066ef4d722d992af48d3ca1ce23848515272daeb15f53a2d6ab99539daf282f971f4a343c502e6fee7c82df4fcb94a16fe409751e292cac9d996a7191d5ccb5ce47c9f3e46c898609ca71aebc54ae205387be9127d4994c1616579e9450e74bc933e44c89860be6cb27f73d47fc41513942dfc813ea4c268d17d7d82794909d29a9ce6e14bf25df9468d8603efcce8ea7c9619233f48d3ca1ce6492a49de5d88bcb3f971c48c975f6ffd7c3e4af241a3ed89ebf15bf9dcfeb2a67e81b79429dc964197371f9d1228b2bce92ea7c0d79b67c5da28184e9f9f2ce2f9063651ba16fe409752693252daeb15f536271ad66a975f6ffffede5f5728e44830ae3f13b34de223f27fefd6f2bf48d3ca1ce64b24cb5b8c86a6aa9b31fa13c48fc0984174934c0d09d2fdaf311f1d51b0f916d87be9127d4994c1616579ed45a675f53e049f25989861af6f645f1bb30ae2273097d234fa83399345e5c63bca664e93525b233d479df66c0cf0cf86502ce1968e7d7f47d795e3fd2bfb2cc31ace73ca1ce6492a49de5d88bcb3f971c08756ecfd5c4ef2678bb9c21d130ac81dfb27782fca65c53e61cd6739e50e77ca9ee537fc75c5c7e5a89c515873a77cbb5e531f21e394ba261b904beb2e2fbe471727d29e5f7c97ace13ea9c27ae8787bf3f07a89aa4c535f66b4a2caed550e761f11df3ba721ff1ebdf3ee3ddef712fe91d06befceea7c4cf70fcaedc4f6e2025361cd6739e50e73c713dd2f0af660330d5e222aba1ced3c6d7b3ff5979a4fc77f953394d7c967c3488a7f60ff267f20af133187716bf76bf94a6cb7ace13ea9c27ae731afeae77151b0016579e50e73c89eaec0f2fba99f8bdf1ff511e228f12bf0be1387999bc56fe50de2f7f217e84fe253955fc0cc387e47fca5bc59f9af742f91df1d3f50f95fbcadde436723df1ef68c9613de70975ce97e6f0b72a36003ed0b14f28213b439df3843ae70975ce13ea9c27ae8b6b7df0feafb6e80d40da598ebdb8fc73c98150e73ca1ce79429df3843ae78bebe2c19fb8eeb6d80dc0988bcb4f2bb1b8e250e73ca1ce79429df3843ae789ebe1ba78e85f72ffd7c56f00d2e21afb352516d76aa8739e50e73ca1ce79429df3c4f5705dd2f0af620330d5e222aba1ce79429df3843ae70975ce13d7d975f1b0f7b323556c00585c79429df3843ae70975ce13ea9c27aeb307bb07be877f351b001fd018af29597a4d89ec0c75ce13ea9c27d4394fa8739ea4e1ef0d92eb648bde00a49de5d88bcb3f971c0875ce13ea9c27d4394fa8739eb81e1ee8ae8f877f151b803117979f566271c5a1ce79429df3843ae70975ce13d7637df82f7e03e0ab1af920c67e4d89c5b59ab1ea7c19b99dfc67f90d798abc489e2bbf26bec2dce5a5d6fab39ef3640e757613f6a71ffe823c507e49ee21be94f2cde510293dace73c713dd2f077adcdb5b2c56e007cd0532c2eb29abe753e5adcd09e2eef105f6ef62289ae27bfee4cf1a5686f2db5dcd959cf79b2ad3a5f5a7e557ca9e5afc95ef7057fb6c397c5f71d6f94ef2a979552c27ace13d7797df89beb658bdc00b0b8f264d33a1f2bf797e789af33ef0f88899a5a1f7f2fcf92253c226a0beb394f72d7d9cdd543ff83728144ebbbab6f8aef63fe7c87ff2457151fd79cc27ace935467d7c72fb1b8de89ffcc16b901f00d1fe335257371585c71d6eb7c98dc547e5dfe9b7c44727d76bd1bdf036489613de749ce3adf493e27d15a1edbf7c5f7457fe0933f04ca1fd4e463dd5658cf79e23aa7e16f8bdf00a41dcfd88b6b6e3be86da759673f95ff70f15397fe8cf7a801e5f461b9962c21ace73cc959673f227faf446b37a71f8aefb3deacfbdc9b1c613de749aab307bd6b9d2c7a0330e6e2f2d34a2cae38ae8707ac5f77fc986cfaba7d4ee78b3fe6d6bfbf52c37ace935c75f6ff7eb4cc6193bccef761df979f283ef1708ab09ef324d5797df85b9f0d40113d94b349a78deb7b0b79817c41a22632471f97a91ada94613de749ae3afb59b23f97688dced117c5f7f55b8a6b3434ace73c49c3dff5719d6cc806a0881aa7831e7b71d51ed7f39ef23af9b6448da2043f92c7cb188d2c4758cf7992abce0f9373245a9b25f07ddf3dc0bdc0b5ea1ad6739ea43abb3eae53d26703e09fe3a7fefd33679d29165791673d8e14bf16e8d704fddaa05f238c1a42a93e2a57973987f59c2739ea7c45f96389d662a9dc137cfe82dfb97094ec15d6739e34ebec3a35f5d9001431fc1d1fb40f2c5a305db91835ee2c7dccf7923f13bfb738bae32f855f7f7d8ccc7571b39ef364ea3a3f58be27d11a5c0a9f377092f842456dcfaeb19ef3a46df8f7d9001431fcd38e67ecc555c4ae67a41c2ebf2d7e1f7d74075f32bf53e02a3297b09ef364ea3afb423c7ef62c5a734be60b123d560e1587f59c27a9ce6dc3dffc3b48f6da0078f8cffea5d23117970b54dbe2f27b805f234b7b8abfab1fc853c58b7f9b613de7c9947576e3f4334bff24d15aab85ef53ff43ae23ace76993d6f36ec3dffc7b48da36001efefe59c50c7f1f40b460ba70716a595c6e50be2a982f0612dd716bf675b9af6c23ace73c99b2ce7e0abca477c6e4e2773ddc47fcac4054c7bdb09edb13ad67d72bb2c906a0dae1efc1b8e41c297ebffe6912dd4971c0c9e2ab18e60aeb394fa6aaf3b5e54f245a4b38c09f6bf064f14991514d23ace7f6b4ad67d72cb2db06c0c3df27fd31fc17961bc91be43c89ee9488f924c837899bd594613de7c91475be9cfc815c28d11a42cc27e0faa5c79b4854df84f5dc9eddd6b3eb16d96d0350c4f0777cd03e80f583eec307eea7959616df61fc54b61fc94677406ccecdea77c4779429c27ace9331ebeccfb9f095f27c5dfd68cd60731f127fe477f4f200ebb93dbbade768f89bff7dd2dc0014f5c87fac3b715a5cfeb94b8a2fd2e1ab77457736f4e7974efc96aeb11e8db09ef364cc3a7b483d48be22d11a417fa7c8dd24d59af51c6793f51c0d7ff3f724d50e7f17c2af772c6d71f9a97ebfa52dba73613c7eaba4cff2f65aec1bd6739e8c55e723c4d7eeff92446b02e3f1c7175f5758cf3bb3e97a6e0efd267f5fd21cfeb3ae733a68dfe0e860bb701196b6b3bc92f8b5eaa55fb8676ebe2bcf140f872e613de7c91875be82f8e59f6f49b406308d0bc41f21def5beb5e47459cfcda1dfd41cfe7ebb5f9527fcb9592e2187c873c4d7b78fee44c8c3d750f8efb2c9c58458cf7932b4ced790974ac9d7ed5f025f41f1b7c4c3aae6745dcfcda1dfd41cfeb3ef1b34cb387e0dfa11728644771a6c87cf047f9bdc40a2b09ef364489dfd32da1bc51f211dfd8eb11d5f159f285863faace7e6d06ff206a088e1eff8a07d83a303ec2abd465a7a7ca191cf4b7427c17c7c50fc2e0cafbb14d6739e74adb32f83eddfd589c2cb68f3f6577273a9297dfa4634fcada847fe3e68dfe8e800bb58c209527e54e90fe889ee14982f3f85f96ab99d8c3dfc4b5ecf53a4d937a2baadbb8dbc527c2e47f4bbc37c1d2f73fafc8e29d2753d37ad0f7e2bee697fdfe8e8e036e5ef2fbd59fa24245fc4c79fb615dd11500e5f05cde76cf8aa71d17addcb12d6f354d9b4595e537c521f97eb2d9f2f6cf65f257de8d0923264f85b1afae69f5144df48073df66ba425364b9f9de90b8dd4fe213d4be4a7997d81a647cae5255abfeb4a5fcf5366afbe711979a8f87af46ca497c7cfe03c40969231e620c35f7cd025e6df0befe7af833778ef93ff22c7ca12d7f39469eb1b7ea4ff28798ff853e9a2da6359de2abe4263c9196b0eae0fff5987e17f20f717bf6e1c2d702cdfa9f2fbf28b729430fcdbd3ec1b7ebff83de4e5c249b2f5f2a779de564accd873b088e1efa483f68d8e0ea68b620e7a2ddeb97a071b2d6ad4c9d777f0bb091e2fc708598d6be2da9c24bc5486c42ff33c4f3c574a8a6f6fdfd7fcd715f7c8dfc37fe806a088d73a82f80cf16f48b49881c46be40fc5e786dc51fcf6b55ae20df2ede509e28db24fa88c6a04249f14bf1434f7a43958fdf0efbb01f0f79538fc7d1de6e70b2726a12f0fc213e429f27372a4941e6f6cbcc1f146c76ff7fab2f0fe7cf4e167867e53e69a31877f3173301db45fdb6c0e7f8b0e6c37fe9ef41a6949c3ff5af22989162d30849f2978afbc587c72a1cf27f015eee6b439b8b4dc50ee25fe60a517cabb8447f698822ff2e47783cc297ea7577a101ccdb62e3c078b1ffe161d5c1bfffb124f90f2d9c95cbf1fdbe04744fea8689f5bf01a79863c443c88ef2cb7120f66bfbe7e65f1a6c18f4ea2a6e23f73f3f209787ee78a9f6ef5f7fa67f867f967fae3939f26be18925fabff3b3957a2db064ce9db72779943d21c1c7bf8cf3a3e685fc7be6df85b748011ffdbd286ff65e503122d4e60eebc693d53fcbe6b4eba43a9fc2e1b0fde6da5cae1efa4e1ef4714cda1df141d64a49883de1f3f1afa8e440b1200908faf04e997c5b6110fffea4ef86b0effa11b80225eebd81fbfcee3f726478b1000b01d3f969c2708a647fe630fff59cfc134fc7d63fd94c7900d80ffbea4e1efe3f5c958d1e203006cdf0b64ea7932e6f02f660eb60dff3e1b00ff5d7acdbf84e1ef93a7fe5aa2050700980fbfddd49f963745d2f01feb35ff22e6601afe2eaa0f7cc806c07f5ed2097f5717bf77395a680080f9f90b19fbe25a530dff59c707ed1bd91cfe7d3700fe331fb4371325e416c2e78b0340797c72e055648c4c31fc8b988369f8fb060fdd0094f4c8df175ce1fdfd0050ae6fc98d6568c63ce1af98399886bf5ff71fba0128e9843f5f718d4bfa0240f97cb1aabe170d4a8ffcc71efeb39e83e9697f5fdf3e0dffbe1b007f2de2a015bfcdef25122d220040992e944748978c39fc8b9983ebc37fc806c04a19fe3e4e7f104bb4780000e5f307b66d328bd2f0f7ac8b067a17c5cc41dfb8f4a106e9a9ffbe1b00ffb9bfb784131dfc6126274bb4600000cbf136f17c6bcb14c3bf8813fe9ac37fe806c0dfe71dcfdcf3d3e20f5489160a0060793e229792f5543ffcfdd4ffd00d4029c3df67879e21d10201002c973fcdd29f7cd98c67a0675a34d0bb2a650efef3f0f72ec5c37fe806201df4ac5feb508e157f1a5ab4300000cb77aa5c46d223ffb187ffdce7e04f867f7af4df7703e0afa51cf4d172ba440b0200508f4fc91132c6f02fe941f03fc737d4c37fc806a0a4e1efddde97245a080080faf824f0a3241aea9bf2f0f79c2c66f83be9d17fdf0d80ff3b0dffb9e750f16e2f5a0000807afd89f8f303a2e1be97e6f02f2a433600feea7f57c241fbf6fb0322a25f3c0000ef103f508c867c9b6287bf33640350caf0f731fe9144bf70000092d74834e8db94f20c7898be1b805286bf5f8b799344bf680000d6fd578986fdba34fc8b79cd7f3d5d3700fe9a867f0907fd32897ec10000b4798a4443df8a3bdbbf2d5d360069f8fbad8325e41912fd620100d8cb6f4a34fc3d0b8b1ffecea61b007ff5df95f0b4bff348897ea100006cc29f22f8008986ff22b2c906200dff521ef9df4f2e96e8170a00c0a6ce977bc8e286bfb3c906a0a4e17f57f9b144bf480000bafa81dc5a1635fc9dbd3600fef35286ff4de55c897e810000f4e5cf8eb9a62c2abb6d004a1afefe68c7bf97e8170700c0509f11bf0cb098441b002b69f83bef96e8170600c0585e2b8b49b401f09f9534fc1f2dd12f0a0080b1fdb22c22cd0d809536fc6f283e4b33fa25010030369f14788c149fe606c0ff5dd2850dfcbe4c3eda170090db67c557c72d3a690350e2558dde26d12f060080a9bd418a8e3700250eff874af40b010020978748b12971f85f5b7e28d12f0300805c7ced9963a5c89436fcfd9acbe725fa450000909b67d24f099938af93e8170000c0b6bc51c88479a04485070060db7e4dc804b9869c2351d10100d8369f9b761d2123c61f4a748a44050700602ebe20fee86032525e2151a10100989b370b1921b7948b252a3200007374772103e28b147d5aa2e2020030575f17de1a38208f97a8b00000ccdd8b84f4c81585b3fe0100a5ba50ae2f73ccac3ff5f71d121514008052fc8dcc69d8faeabfbe3d7e897d96b98b44850400a0348f9639a439fc67b901f07bfebf2c5111010028cdf7e50ab2cd3487ffbfdcff757679a644050400a054ef946da639fc67b901b8ba9c2751f1000028d9b6ae0de08ffdf7d03f78ffd7596e004e92a8680000946e1bd706f0f0f7e04f66b901b88f440503006029725d1bc0aff9a7e17fc9fd5f67b901f08ee874898a0500c052f8da00c7ca94591ffeb3de00fc96448502006069de2a53a539fcfdaeba596f00feb57c4ba2220100b0347e16e0aa32763cfc3dd83df03dfc67bf01788c4405020060a95e2563270d7f3fb09efd06c037e634898a0300c0529d2f635d1c283df2f7c0f7f02f6203f030890a0300c0d2bd4486261afeb3df00f8fffcab1215050080a53b578e90be690eff7fb35f111b80074b541000006af17bd227d1f02f6203e06b127f51a2620000508bb3e410e9120f7f0f710f7a5f47a7a80dc07d252a040000b57992744973f817b501f0cee5331215010080da9c211eda7b253df2f7a04fc3bfa80dc0bd252a000000b57ab4ec96b6e1df7703e0ab0566cfdf4a74f00000d4ca9f14e8c11ca5f99affbfdd6fc806c0c3df3f336b6e21d181030050bb7bc97aa2e1df7703e09fe3a7feb30f7fc7173d880e1a0080dabd5e9a693eeddf1cfe7d37005b1bfe0e97fd050020f61d690ee8b6e1df6703b0d5e1ef1b101d300000d8c7437bb747fe49970d8087bfafbfb3b55c5aa283050000fb7878ef35fc6d930d8087bf7fd65687bf7379890e1600001c74d0459206f9bfdb2f1afeb6c9066016c3dff1531ae74874d00000d4ee64690effbe1b000f7f9ff4378be19fe2838b0e1a0080da3d5d9ac3bfef066076c3df79a144070d0040cdce97ebcad00dc02c87bf736d890e1c00809a1d27ebc3bfeb0660b6c33fe5af243a7800006af459395c866c00d2f0dfda7bfd37c9dd242a000000b5f199ffb79368f85b34fcad39fcfd76bf593ff277d2c50d4e90a8100000d4e495120dfe241afed61cfe5bf964bf2e695ed9e86af23d898a0100400dfe517c8d9c68f027d1f0376f008a18fe8e87bf6f703a287ff671541000006af040690efb4834fcada847fe1efebed1e9a00e11ae0b0000a8d107a439e8dbac0f7e2bee697fdfe8f503bb91f8bd8f5171000058a273e518599f8991e6e0f703695fe5cfc37fd667fb37877f7450c973242a1000004bf41489e66164b1c3dffc29815f94a84800002cc9ff96c3249a8791f5e13feb7419fec9cfc9c512150b008025f07bfe6f2bd11c6ce30d4011c3dfd9ed35ffddbc5ea2820100b0047bbde73f52dc23fff49a4574306dae286748543400004ab6c97bfed7153bfcbb6e00ec2112150e0080926df29effc4f3b3a813fefc19c4cde1df6703e0ef798f44c50300a044c74b34f3229e83c50f7f8b0eae8dffbd7fce91729a44450400a0245f95cb4934f7d6790e16f3b4ff25a46df85b748011ff5bff9c74d0b7119f2d191513008012fc58363debdf73b088e1efa4e19f2ef11b890e32121df4ef49545000004af03489665ea4b847fe1efe4337006daf75f8ffe363121515008039fb33f167de44736f5ddb1c9c55d2f0f78df519ff433600fefbbd0efa68e16383010025f9b65c55a2d9d7b4c91c9c45da867f9f0d80ff2ebde6bfd741df57a20203003037beaaedbd259a7d4d5de6e0569386bf3f82d0c37fc806c07fde3ce16f937095400040095e2ed1ec6bea3307b7120f7fdfc8e6f0efbb01f09ff9a0bd99e812ff7f9c2a51b1010098834fc9e1b23efb9afacec1ad240d7fdfe0a11b80213b9e1bc9f912151d00806dfa815c4fd6e7deba221ef93b69f8fb75ffa11b80314e74788244850700609b1e2acd991749c37ff6aff9fb461e2c69f8f7dd00f8eb5807edef3f51a2e20300b00d6f91f561df34e61c9c34ebc37fc806c0c63ee843e58b12fd120000c8e9d372944483dfa6988393c437ee5f88afef9f9efaefbb01f09ffb7ba738d1e118395ba25f06000039f83a35d79168f09b67a167671127fc3587ffd00d80bfcf3b9ea9720ff1fb2da35f0a000053f2fcf9258906bf790e1637fcfdd4ffd00dc0d4c33fe51912fd62000098d2f3251afc49ae3938381efedea578f80fdd00a483cef15a87ff3fde2dd12f07008029f83aff3e1f2d1afc96730e0e4a1afee9d17fdf0d80bf6ee3a05deccf49f44b0200604cdf902bcbfad0b7dc0f8207c737d4c37fc806605bc33fe56a729644bf2c0000c6709edc46da86bfe76431c3df498ffefb6e00fcdf69f86f3377918b24faa5010030d42364afe15f54866c00fcd5ff6e2e07fd44897e6900000cf14259d4f077866c00e634fc53de2ed12f0f00803e4e904324da00cce119f0dee9bb0198e3f0777cdb4e91e897080040171f972365b7e15fcc6bfeebe9ba01f0d734fce77ad047cb7725fa650200b089af8ae7c9fae02fee6cffb674d900a4e1efb70ece3d77900b25faa50200b09b7f921b4834fc3d0b8b1ffecea61b007ff5dfcdf169ffb6fc17897eb10000b4395ffcceb2dd86ff22b2c906200dff121ef9afe78d12fd82010088fc9a2c7ef83b9b6c004a1dfe8e8fe38312fd920100687aaaac0f7ff32c5cd4f077f6da00f8cf4b1dfe293e79f1c312fdb20100b0e7c86ec3bff8d7fcd7b3db066009c33fc54fdf7c4ca25f3a00a06e2f93f5c1bf98b3fddb126d006c49c33fc59fdef4bf24fae50300eaf46a8986ff62cef66f4bb401f09f2d6df8a75c4ab8501000c0de2aeb57f95be4097f519a1b005bf2f04f39423e2bd1620000d4e1dd72985439fc9de606c0ffbdd8a73ad67259f9a2448b0200b06c7f2c874b73f8db22cff66f4bda002cfa758e965c41be22d1e200002c93df15165ddf7fd127fc45f106a0c6e19f7265f9ba448b0400b02cfe709fcb4873f02ffe6cffb6d43cfc53ae2aa74bb4580000cbe013c0fdcceffaf05ffcd9fe6da97df8a7fc8c7c4ba245030028dbe765fd93fdaa3ae18fec9e6b0b1f230c00cbe273bdae2e0c7fb26b6e226749b488000065394d8e91e6f0b7aacef627bbc72f85f8dd103f25b793b3255a4c008032f865ddeb49dbf0e72570b232fcd302b993b0090080329d213795e6e0aff66c7f12270d7f7f626073a1d82dc58b285a5c008079fa865c5f9afdbceab3fdc9ceec36fc93ebcad7245a64008079f1155eaf29cd3ece097f64259b0cffe46af21989161b00601e3e25bcd58fec99f5d7fcf7e28b479c2cd1a203006cd75fcae564bd7773b63ff949d223ff2ec33ff1b5a34f9468f10100b6e303c2b5fdbb65e99ffabb2343867fe28f8e7c93448b100090d7f1722969f669cef66f8febe1e1efcf01aa2669f86ff29aff5ebcb85e2cd1620400e4f14a3944d6fb3367fbc7690eff6a3600630fffb4b89e20174bb4300100d379beecd69fc96a9ac3dff3b08a0dc054c33fe5217281440b1400302e3fe87ab26cd29fc98134877f351b001fe890d7fc9bdace26bdbbfc50a2c50a0018c785f29bd2a53f937d75f12c3c78ffd7c56f00d223ffb187bf7f6e945b091f220400d3385f1e287dfa73cd715d3cf893c56f00c61cfe7e5a69d3c5751df9ba448b1700d08f3f97e51e32a43fd716d7230dff4beeffbaf80d401afe63bfe6bfe9e23a4a3e2ad122060074f325b9918cd19f6bc9faf0af620330d5f0ef1a17f975122d6600c0664e125f8575ccfebcf43487bf9f1da962033097e1dfcc63c527ad440b1b00d0ee4572a84cd59f9718cf410f760f7c0fff6a36003ea0a9cff6ef93bbc8f7245ae00080557e4795df5e1df5661bb33f2f2d69f87b8354c506203df2cf75b67f9ff8a3294f9568b10300f6f1e7f8df52a2de6c53f4e725243df2777d3cfcabd8008c39fcfdb4d2948bcbd7aafea0448b1e006af717b2fe51beb9fa73c98986ffe23700beaa910f625b67fbf7897ffecb255afc00502b5fd37ffd037d72f7e712d31cfe9e85b6f80d800f7a8ae19f2b0f951f4b744700805af8e23e6d57f6b36df4e752120dffc56f004a1ffe29b791ef4874a70080a5fba6dc41a2de6c0cfff6a439e8faf825f06a3600bee1733cdbbf4ffc7ad7a725ba7300c052fd2fb986447d39d9767f9e739ac3bf8a0d40daf18c3dfcfd73b719ef72df25d19d040096e68d7284447d39994b7f9e5b9acf80a7e1bff80dc098c3df03778e8bebd7e51c89ee300050ba33e54112f5e564aefd790e691bfe7d3700453cbb52e2d9fe7d7315f98844771e0028d507e46a12f5e564eefd799b49c3dff5719d6cc806a0881a37773cd182e9a2b9b8e61c6f781e2fe7497447028052fc401e25514f6e2aa53f6f23d1f0efbb01f0cff153ff550eff924e7a3856fe56a23b1500ccddc9726d897a725389fd39579a73b039fcadcf06a088e1eff8a07d60d182e9cac5287167e91a3c4b2e90e80e060073e3672f9f2ad107f9444aedcf39d236fcfb6c008a7ae43ff6f02f62d7d3929bca1724bab301c05c9c22ee57512f8e2ca13f4f913407db86bf75d90078f8fbe5e55967cce1ef022d6971f9585e26174b74c703806df1c79ebf400e97a81faf5b5a7f1e339b0c7fdb6403e0e1ef9f55ccf0f701440ba60b1767a98bcb57cefaba44774200c8ed4b727b897a7164c9fd7968a239d81cfa4d9b6c00aa1dfe4b3ea1c4afadbd41a23b2300e4e06723fd213e4749d48b2335f4e7be699b83cda1dfb4db06c0c3df27fd31fc179c7bc91912dd3901602aff20f790a80fb7a9ad3f77c96e73b039f49b76db001431fc1d1fb40f60fda0fbf081fb69a59a72a4bc5ba23b29008ced78b9a2443d783735f6e74db3db1c8c86bfb56d008a7ae43ff6f0f7cfad310f96b324bac302c050df95bd2ee5dba6f6fedc964de66034fc2dda005437fc5d08bfdec1e2daf76cc01f88cfc88deec000d0d58fe515d2e7513ffdb93d9bcec1e6d06f5adf00a4e13feb3aa783f60d8e0eb60b17819de5ce5c47fe4ca23b33006cea8fe50612f5dfbdd09fdbd3650e36877e5373f8fbed7e559ef0e7c5455693ea7c1ff98a44776c0068f379b9a744bd7713f4e7f6749d83cda1dfd41cfeb3af33c33f4fd6eb7c69f16539cf96e88e0e00893fb2d71f467698acf7dd4dd19fdbd3670e36877e933700450c7fc707ed1b1c1d6057e93525b2336d75fe69799d5c24d11d1f40bdd2ebfc5792f5ded115fdb93d7de66034fcada847fe3e68dfe8e800bbe0849238cd3a47754b6e2e1f91a80900a8cffbe5fa12f58baee8cf7136edcf91f5c16fc53dedef1b1d1ddca6fcfd2cae387d16d7fde4ab12350400cbf739b99bf4194aebe8cfed1932fc2d0d7df3cf28a2cee9a0c77ecd9fc5b59a2175f6f9014f13ce0f00eae1d7f91f2deea9f4e76933c61c64f88b0f9aac66ac3afbfc80d70be70700cb7581f81345fd897df4e7e933567f5e1ffeb30ec33f4fa6a8b3dfeffb21899a078072f975fe6b0afd394fc6ae7311c3df4907ed1b1d1d4c17c51cf416e23a8ff1da9dadd7d91f32f409891a0980729c2c3f272953f60d7220d5d5b9b9e3f1f04fa203da443a68ff5c7220a9ce632faea8ce7712ae280894e744b9b5a4e4ec1b3567aa3acf3ae9a0d7877f9f0d80bf87c515a7b9b8fad4b6a94b9d6f22ef147ffe77d46c006c9f3f03e4ad723d69665b7da3b65459e774d07e2dc8373a121d60c4ff96c515c7d7794e9baca8765df4adb35f43f4c5847cd190a80101c8ef47f23fc427f3ae670e7da3865459e74d86bf4507b9ceff2e1d34594daaf3d88bab6ffca9602f961f48d490004cef7bf25cb98c44995bdf586aaaacb30ffa12e2e1efa73cd2d31ebb890ed8fc772cae38735e5c7e3bd1ef883f273c6a5000c6f72d79a21c226d61f8e749b5755e1ffe9b6c0092f5036771b567acc56553d5d9bffbff4fbe2151c302309c3fd9f3e1e2fbf15e29a16f2c21d5d5393df2f78df5813737005d3601493a68ff5c7220cd9d6554b7ae72d4d9b7f721e28f128d1a1880ee4e91fbca26c3a1c4be5162a6aaf3ace3836e0effa11b0016579cd2efc4fefff1b504fe5aa28606606ffed0aebbcaa629bd6f94922aebec1be71be94f214ac3dfd637009b6c02fc6f585c71d2e2daebc4ca4dcca1ceb793b7c80f256a72000e38477c596e7f6a67972cad6fcc3555d6d9372e0d7f1fb8edb509b0bd0e9aac66aac535871c2a0f155f992c6a7c40ad7c7d0d5f82fbc1e2fb6dd72cb96fcc29d5d6d937f26049c3df9a1b80dd360156e441674e4d8beb1a729c70d2206ae693fa9e21474bdf30fcf3a4fae1ef1b6c6903605d3601c6e26a4f7a5745b460ba2aa5cebe78862f37cc4b04a8853f7afbb5721bf150199a1afbc63652659dd3f0f753ffbed19686bfad6f0076db04f867b0b876c64d202daea86e5da53a8fd15c72c6ef69fe75f9a8448d1328959fe2f7676a3c48dc23c7087d234faaacb36f5cbab4a16fb0a50dc0269b004b07ecff6671c51973712da9ce5797670b2f11a0645f92a7c9bf973143dfc8932aebec1b97867f7af49fb46d02cc07b8ce7f9e0e9aac262d2ed7325a305db8d64bacb3d7e11de5cdc24b0428c1f7e5d5722b9922f48d3ca9b6ce6eba3e700fffc4373e491b005bdf0418c37fef341757aa575fb5d439bd44e0b3a52f90a8f902db709e7c401e20be3f4e15fa469e545be734fcfde83f3d03b0db06c07c80117f1f8b6b67b8130f8fdf52f81fe53572ba444d1998d257e515f20be2fbe2d4a16fe449b575f681fb86a6e1dfdc00ac6f022c6d009234f8cdffde9b09b233632d2ea3cefbe2cf3f7f92f8ca693c3b8029f851fe9fc863c51f8b9d3bf48d3ca9b2ce69f8fbe0adef26c0fc3d2cae9d493b4bd7adb959ea8b3b719cc3e43ef206f947899a39b089af893f67ffeee2d772b711fa469e545be734fc9b1b00db7413601efcfecaf08f936a9c6a152d984df9fbb913c789ea7c5379bafca5f0ec0076e347f91f946d3dca5f0f7d234faaaeb36fa80fde9a1b80dd3601e6623531fce3a4c5e59a79710c419ddbb3499d2f23f7139e1d40328747f951e81b79527d9d9b1b00ebb20948fcef585c3bc39d384ffad6d9cf0e3c55de2ba7493420b02cbefceef1e247f9c7c81c43dfc813eaacac6f006cb74d80b96009c3bf3d697179710c55e4e2ca94b1ea7c05f12341bf64f01e615350363fba7f87f804515f4fe2525242e81b79429d15df6873319a36d904f8cfbd8b223b33e6e2729db913c799bace7ed9e0e7c51fdae2670a78dbe13c7d5dde294f913bcba5a5c4d037f2843aef8f6f78e2a234f9c09a9a1b00ff3dc33f8e6b99364943b9eed439ceb6ea7c59f1fbbf7f47fe48389f202f3f33f36ef16576ef2247ca1242dfc813eadc888bd1b4d726c018fe715c93b116977f866b4d9d77668e75bebcf8e58367cabbe493f25d89061836f36df9849c207e06c6cfc41c254b0b7d234fa873101764ddfa26c07cb0e6ff6671ed4c5a5cae9117c750d4394e6975f699e53ed9cc8f541f26c7c99be42fe4efa5d6b726fe587c353d5fdaf9ff97df135fead94fdfff8cf82d553584be9127d4b9252e4ac407b8ce7fcee2da993117977f866b4d9d77668975f66db892f8c363ee2f4f96df97f7cbe7e41c8906e8dc7d4f3e23ef13bfcdee89725fb9b9f8644bff1e6b0f7d234fa8f32e49c569e38335ff378b2b4eaa9317c750dc89db536b9d0f976bc94de4b67257f16721f8f3e57f431e277e3dfc39f2527995f81314fd52c449f297f2b7f277e293e5be23fe74c58be4dcfdffdb7ffe79f153ee7e76c2dfe7d7d9df22fe74bb97c973c5ef9078bc3c5c1e2cbf247793dbcbcde458f1097825d63977e81b79429dc31c74d0ff058092ac6f81d0c12a0000000049454e44ae426082);

-- --------------------------------------------------------

--
-- Table structure for table `users_log`
--

CREATE TABLE `users_log` (
  `UsersLogID` int(11) NOT NULL,
  `UserID` int(11) DEFAULT NULL,
  `UserName` varchar(45) DEFAULT NULL,
  `TimeIn` datetime DEFAULT NULL,
  `TimeOut` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`ProductID`);

--
-- Indexes for table `products_log`
--
ALTER TABLE `products_log`
  ADD PRIMARY KEY (`ProductsLogID`);

--
-- Indexes for table `product_transaction`
--
ALTER TABLE `product_transaction`
  ADD PRIMARY KEY (`ProductTransactionID`);

--
-- Indexes for table `stocks`
--
ALTER TABLE `stocks`
  ADD PRIMARY KEY (`StocksID`);

--
-- Indexes for table `stocksindividual_log`
--
ALTER TABLE `stocksindividual_log`
  ADD PRIMARY KEY (`StocksLogID`);

--
-- Indexes for table `stockstotal_log`
--
ALTER TABLE `stockstotal_log`
  ADD PRIMARY KEY (`StocksTotalLogID`);

--
-- Indexes for table `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`TransactionID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UsersID`);

--
-- Indexes for table `usersinformation_log`
--
ALTER TABLE `usersinformation_log`
  ADD PRIMARY KEY (`UsersInformationID`);

--
-- Indexes for table `users_information`
--
ALTER TABLE `users_information`
  ADD PRIMARY KEY (`UsersInformationID`);

--
-- Indexes for table `users_log`
--
ALTER TABLE `users_log`
  ADD PRIMARY KEY (`UsersLogID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `ProductID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `products_log`
--
ALTER TABLE `products_log`
  MODIFY `ProductsLogID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `product_transaction`
--
ALTER TABLE `product_transaction`
  MODIFY `ProductTransactionID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `stocks`
--
ALTER TABLE `stocks`
  MODIFY `StocksID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `stocksindividual_log`
--
ALTER TABLE `stocksindividual_log`
  MODIFY `StocksLogID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `stockstotal_log`
--
ALTER TABLE `stockstotal_log`
  MODIFY `StocksTotalLogID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `transactions`
--
ALTER TABLE `transactions`
  MODIFY `TransactionID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UsersID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `usersinformation_log`
--
ALTER TABLE `usersinformation_log`
  MODIFY `UsersInformationID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users_information`
--
ALTER TABLE `users_information`
  MODIFY `UsersInformationID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `users_log`
--
ALTER TABLE `users_log`
  MODIFY `UsersLogID` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
