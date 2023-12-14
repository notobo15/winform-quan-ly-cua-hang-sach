-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               8.0.30 - MySQL Community Server - GPL
-- Server OS:                    Win64
-- HeidiSQL Version:             12.1.0.6537
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for bookstore
CREATE DATABASE IF NOT EXISTS `bookstore` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `bookstore`;

-- Dumping structure for table bookstore.accounts
CREATE TABLE IF NOT EXISTS `accounts` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext,
  `Gender` int NOT NULL DEFAULT '0',
  `Phone` longtext,
  `RoleId` int DEFAULT NULL,
  `BirthDay` datetime NOT NULL,
  `IsDeleted` tinyint NOT NULL DEFAULT '0',
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL,
  `Password` longtext,
  `UserName` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_Accounts_RoleId` (`RoleId`),
  CONSTRAINT `FK_Accounts_Role_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `role` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table bookstore.accounts: ~20 rows (approximately)
INSERT INTO `accounts` (`Id`, `Name`, `Gender`, `Phone`, `RoleId`, `BirthDay`, `IsDeleted`, `CreatedAt`, `UpdatedAt`, `Password`, `UserName`) VALUES
	(1, 'nguyen thanh binh', 1, '0987654321', 1, '2023-12-11 00:00:00', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '123', 'admin1'),
	(2, 'admin2', 0, '0987654322', 1, '2023-12-12 15:39:16', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'admin2\r\n'),
	(3, 'admin3', 1, '0987654323', 1, '2023-12-13 15:39:17', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'admin3'),
	(4, 'manege1', 0, '0987654324', 2, '2023-12-14 15:39:17', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'manege1'),
	(5, 'manege2', 0, '0987654325', 2, '2023-12-14 15:39:17', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'manege2'),
	(6, 'manege3', 1, '0987654326', 2, '2023-12-15 15:39:17', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'manege3'),
	(7, 'seller1', 0, '0987654327', 3, '2023-12-13 15:39:17', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'seller1'),
	(8, 'seller2', 1, '0987654328', 3, '2023-12-13 15:39:17', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'seller2'),
	(9, 'seller3', 0, '0987654329', 3, '2023-12-13 15:39:17', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'seller3'),
	(10, 'accounter1', 1, '0987654330', 4, '2023-12-13 15:39:17', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'accounter1'),
	(11, 'accounter2', 0, '0987654331', 4, '2023-12-13 15:39:17', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'accounter2'),
	(12, 'accounter3', 1, '0987654332', 4, '2023-12-13 15:39:17', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'accounter3'),
	(13, 'user1', 0, '0987654333', 1, '2023-12-13 15:39:17', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'user1'),
	(14, 'user2', 1, '0987654334', 1, '2023-12-13 15:39:17', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'user2'),
	(15, 'user3', 0, '0987654335', 1, '2023-12-13 15:39:17', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'user3'),
	(16, 'user4', 1, '0987654336', 1, '2023-12-13 15:39:17', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'user4'),
	(17, 'user5', 0, '0987654337', 1, '2023-12-13 15:39:17', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'user5'),
	(18, 'user6', 1, '0987654338', 1, '2023-12-13 15:39:17', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'user6'),
	(19, 'user7', 0, '0987654339', 1, '2023-12-13 15:39:17', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'user7'),
	(20, 'user8', 1, '0987654340', 1, '2023-12-13 15:39:17', 0, '2023-12-11 15:39:21', '2023-12-11 15:39:22', '12345', 'user8');

-- Dumping structure for table bookstore.author
CREATE TABLE IF NOT EXISTS `author` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FirstName` longtext,
  `LastName` longtext,
  `BirthDay` datetime NOT NULL,
  `Gender` int DEFAULT NULL,
  `IsDeleted` tinyint NOT NULL DEFAULT '0',
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table bookstore.author: ~28 rows (approximately)
INSERT INTO `author` (`Id`, `FirstName`, `LastName`, `BirthDay`, `Gender`, `IsDeleted`, `CreatedAt`, `UpdatedAt`) VALUES
	(1, 'Lê', 'Đỗ Quỳnh Hương', '1980-12-10 11:43:05', 0, 0, '2023-12-10 11:43:07', '2023-12-10 11:43:08'),
	(2, 'Avinash', 'K Dixit', '1980-12-10 11:44:18', 1, 0, '2023-12-10 11:44:26', '2023-12-10 11:44:27'),
	(3, 'Minh', 'Niệm', '1980-12-10 11:46:52', 1, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(4, 'Trần', 'Phách Hàm', '1985-12-10 11:46:52', 1, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(5, 'T', 'Harv Eker', '1975-12-10 11:46:52', 1, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(6, 'Từ', 'Kế Tường', '1975-12-10 11:46:52', 0, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(7, 'Nguyễn', 'Đình Khoa', '1985-12-10 11:46:52', 1, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(8, 'Elly', 'Griffiths', '1983-12-12 11:46:52', 1, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(9, 'Raymond', 'Murphy', '1983-12-08 11:46:52', 1, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(10, '', 'Oxford', '1983-12-11 11:46:52', 1, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(11, 'Yuval ', 'Noah Harari', '1982-12-10 11:46:52', 1, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(12, 'Erika ', 'Takeuchi', '1983-12-09 11:46:52', 0, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(13, 'Viện Giáo Dục', 'Shichida Việt Nam', '1983-12-15 11:46:52', 1, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(14, 'Antoine ', 'de Saint-Exupéry', '1983-11-10 11:46:52', 1, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(15, 'Tô\r\n', 'Hoài', '1983-09-10 11:46:52', 0, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(16, 'Nguyễn ', 'Đình Thi', '1984-01-10 11:46:52', 0, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(17, 'Michael \r\n', 'Sandel', '1984-02-10 11:46:52', 1, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(18, 'Nguyên', 'Anh', '1984-03-10 11:46:52', 0, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(19, 'Bessel', 'Van Der Kolk', '1983-09-10 11:46:52', 1, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(20, 'Lê', 'Xuân Khoa', '1983-03-10 11:46:52', 1, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(21, 'Benjamin ', 'Carter Hett', '1987-12-10 11:46:52', 1, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(22, 'Lê', 'Quýnh', '1981-12-10 11:46:52', 0, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(23, 'Diệp', 'Lạc Vô Tâm', '1989-12-10 11:46:52', 1, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(24, 'Nghê ', 'Đa Hỉ', '1979-12-10 11:46:52', 1, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(25, 'Thương', 'Thái Vi', '1983-03-10 11:46:52', 1, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(26, 'Trang', 'Anh', '1981-12-10 11:46:52', 0, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(27, 'Justin ', 'Grosslight', '1978-12-18 11:46:52', 1, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54'),
	(28, 'Lê', 'Hồng Đức', '1984-05-05 11:46:52', 0, 0, '2023-12-10 11:46:53', '2023-12-10 11:46:54');

-- Dumping structure for table bookstore.book
CREATE TABLE IF NOT EXISTS `book` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext,
  `Image` longtext,
  `Description` longtext,
  `PublicationDate` datetime NOT NULL,
  `TotalPage` int NOT NULL DEFAULT '0',
  `Format` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Quantity` int NOT NULL DEFAULT '0',
  `Price` double DEFAULT '0',
  `Language` longtext,
  `CategoryId` int DEFAULT NULL,
  `PublisherId` int DEFAULT NULL,
  `AuthorId` int DEFAULT NULL,
  `DiscountId` int DEFAULT NULL,
  `IsDeleted` tinyint NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Book_AuthorId` (`AuthorId`),
  KEY `IX_Book_CategoryId` (`CategoryId`),
  KEY `IX_Book_PublisherId` (`PublisherId`),
  KEY `FK_book_discount` (`DiscountId`),
  CONSTRAINT `FK_Book_Author_AuthorId` FOREIGN KEY (`AuthorId`) REFERENCES `author` (`Id`),
  CONSTRAINT `FK_Book_Category_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`Id`),
  CONSTRAINT `FK_book_discount` FOREIGN KEY (`DiscountId`) REFERENCES `discount` (`Id`),
  CONSTRAINT `FK_Book_Publisher_PublisherId` FOREIGN KEY (`PublisherId`) REFERENCES `publisher` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table bookstore.book: ~30 rows (approximately)
INSERT INTO `book` (`Id`, `Name`, `Image`, `Description`, `PublicationDate`, `TotalPage`, `Format`, `Quantity`, `Price`, `Language`, `CategoryId`, `PublisherId`, `AuthorId`, `DiscountId`, `IsDeleted`, `CreatedAt`, `UpdatedAt`) VALUES
	(1, 'Thay Đổi Cuộc Sống Với Nhân Số Học', '42b57c4c-ba30-47b2-9abf-a476de8eeddc.png', 'Thay Đổi Cuộc Sống Với Nhân Số Học\r\n\r\nCuốn sách Thay đổi cuộc sống với Nhân số học là tác phẩm được chị Lê Đỗ Quỳnh Hương phát triển từ tác phẩm gốc “The Complete Book of Numerology” của tiến sỹ David A. Phillips, khiến bộ môn Nhân số học khởi nguồn từ nhà toán học Pythagoras trở nên gần gũi, dễ hiểu hơn với độc giả Việt Nam.\r\n\r\nĐầu năm 2020, chuỗi chương trình “Thay đổi cuộc sống với Nhân số học” của  biên tập viên, người dẫn chương trình quen thuộc tại Việt Nam Lê Đỗ Quỳnh Hương ra đời trên Youtube, với mục đích chia sẻ kiến thức, giúp mọi người tìm hiểu và phát triển, hoàn thiện bản thân, các mối quan hệ xã hội thông qua bộ môn Nhân số học. Chương trình đã nhận được sự yêu mến và phản hồi tích cực của rất nhiều khán giả và độc giả sau mỗi tập phát sóng.\r\n\r\nNhân số học là một môn nghiên cứu sự tương quan giữa những con số trong ngày sinh, cái tên với cuộc sống, vận mệnh, đường đời và tính cách của mỗi người. Bộ môn này đã được nhà toán học Pythagoras khởi xướng cách đây 2.600 năm và sau này được nhiều thế hệ học trò liên tục kế thừa, phát triển.  \r\n\r\n Có thể xem, Nhân số học là một bộ môn Khám phá Bản thân (Self-Discovery), đọc vị về số. Bộ môn này giúp giải mã những tín hiệu mà cuộc sống đã gửi đến từng cá thể con người trong đời sống, tương tự như Nhân tướng học hay Nhân trắc học…Khi nghiêm túc nghiên cứu sự tồn tại và mối tương quan giữa các con số xuất hiện trong ngày, tháng, năm sinh của mỗi người qua Nhân số học, ta có thể hiểu được khá nhiều về bản thân mình, cũng như mối quan hệ của mình với người khác. Nếu hiểu những "mật mã" nằm ẩn dưới những con số, chúng ta có thể kiểm soát cuộc sống của mình, điều chỉnh chúng theo hướng ngày càng tốt đẹp hơn, phù hợp với năng lực, tính cách của mình hơn.\r\n\r\nTrong quyển sách “Thay đổi cuộc sống với Nhân số học”, Lê Đỗ Quỳnh Hương đã sử dụng khoảng 60% nền tảng tri thức từ quyển sách “The Complete Book of Numerology” (tạm dịch: Một quyển sách toàn diện về Nhân số học) của Tiến sĩ David A. Phillips (1934 – 1993) và 40% kết quả nghiên cứu của chị sau khi phân tích hơn 500 trường hợp cụ thể của những người Việt Nam sinh ra trong thế kỷ 21.\r\n\r\n Cuốn sách “Thay đổi cuộc sống với Nhân số học”mang lại đầy đủ những kiến thức quan trọng nhất mà người hứng thú với Nhân số học cần tìm hiểu. Sách bao gồm các kiến thức về ba thể trong một con người, con số chủ đạo, biểu đồ ngày sinh, các mũi tên chỉ đặc điểm, con số ngày sinh, chu kỳ 9 năm, ba giai đoạn và bốn đỉnh cao của đời người cùng ý nghĩa, sức mạnh của cái tên của mỗi người. Các kiến thức này được diễn giải, phân tích và đi kèm các ví dụ cụ thể.\r\n\r\nVới mục đích đem Nhân số học trở nên gần gũi, dễ ứng dụng và mang lại những giá trị tích cực cho mỗi người trong đời sống, chị Lê Đỗ Quỳnh Hương mong rằng trong hành trình khám phá bản thân qua những con số, người đọc có thể hiểu về mình - hiểu được những thuận lợi và bất lợi mà mình gặp phải, từ đó tìm được động lực lớn để thay đổi cuộc sống. Giá trị của cuốn sách “Thay đổi cuộc sống với Nhân số học” nằm ở kiến thức tổng quan về Nhân số học và những lời khuyên sâu sắc để mỗi người có thể chuyển mình theo những hướng tích cực hơn như sống có lý tưởng, mở lòng, chăm chỉ, biết lắng nghe người khác, luyện tập thiền định, tập trung, sống có trách nhiệm, biết ơn và yêu thương…\r\n\r\nTrong cuộc đời của mỗi con người, chúng ta thường phải mày mò, tìm kiếm con đường riêng cho mình mà không biết chắc con đường đó có phù hợp với mình hay không. Đôi lúc, chúng ta phải phải trầy trật, vấp ngã thậm chí lạc lối mới rút ra được kinh nghiệm, bài học. Nếu hiểu về Nhân số học, và thông qua những kiến thức nhất định về ý nghĩa và sự kết hợp của các con số, chúng ta có thể tự vạch ra cho mình một hướng đi tương đối cụ thể, giảm thiểu được các lần “thử và sai”, từ đó tìm được nhiều niềm vui, hạnh phúc, ý nghĩa trong cuộc sống.\r\n\r\nĐó chính là thông điệp và mục đích lớn nhất mà tiến sỹ David A. Phillips và Lê Đỗ Quỳnh Hương mong muốn gửi gắm cho đông đảo bạn đọc.', '2023-12-11 00:00:00', 300, 'Bìa Cứng', 10, 248000, 'Tiếng Việt\r\n', 1, 1, 1, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(2, 'Nghệ Thuật Tư Duy Chiến Lược', '2.jpg', '"Có phải những người chiến thắng các chương trình truyền hình thực tế được trời phú cho trí thông minh và kỹ năng hơn người?\nCó phải các nhà đầu tư vĩ đại có thể nhìn thấy những điều mà hầu hết mọi người bỏ lỡ?\nCó phải các tay chơi poker sở hữu những tài năng mà chúng ta không có?\nCâu trả lời cho tất cả những câu hỏi trên là ""Không hề!"" Họ hoàn toàn ""bình thường"", như bạn, như tôi hay bất cứ ai ngoài kia.\nThông qua Nghệ thuật tư duy chiến lược, bạn sẽ thấy ""những người thành công"" trong mọi lĩnh vực từ giải trí đến chính trị, từ giáo dục đến thể thao, v.v... đạt thành công vang dội là nhờ luôn nắm vững lý thuyết trò chơi hay nghệ thuật tư duy chiến lược, với khả năng dự đoán những động thái tiếp theo của người cùng chơi, trong khi biết rõ rằng đối thủ đang cố gắng làm điều tương tự với mình.\nNgoài ra, bạn cũng sẽ nắm được những bí kíp vô cùng giản đơn để có thể áp dụng lý thuyết trò chơi vào cuộc sống lẫn công việc, từ đó sở hữu một cuộc đời đáng sống."', '2023-12-11 16:21:15', 560, 'Bìa mềm\r\n\r\n', 100, 239000, 'Tiếng Việt\r\n', 2, 2, 2, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(3, 'Hiểu Về Trái Tim (Tái Bản 2023)', '3.jpg', '“Hiểu về trái tim” là một cuốn sách đặc biệt được viết bởi thiền sư Minh Niệm. Với phong thái và lối hành văn gần gũi với những sinh hoạt của người Việt, thầy Minh Niệm đã thật sự thổi hồn Việt vào cuốn sách nhỏ này.', '2023-12-11 16:21:15', 479, 'Bìa mềm\r\n\r\n', 100, 158000, 'Tiếng Việt\r\n', 1, 1, 3, 10, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(4, 'Lý Thuyết Trò Chơi', '4.jpg', '"Đời người giống như trò chơi, mỗi bước đều phải cân nhắc xem đi như thế nào, đi về đâu, phải kết hợp nhiều yếu tố lại chúng ta mới có thể đưa ra được lựa chọn. Mà trong quá trình chọn lựa này các yếu tố khiến ta phải cân nhắc và những đường đi khác nhau sẽ ảnh hưởng trực tiếp đến kết quả.\r\n\r\nCuốn sách Lý thuyết trò chơi là bách khoa toàn thư về tâm lý học, về tẩy não và chống lại tẩy não, thao túng và chống lại thao túng, thống trị và chống lại thống trị. Cuốn sách giới thiệu công thức chiến thắng cho những “trò chơi” đấu trí giữa người với người trong cuộc sống hằng ngày; phân tách các khái niệm lý thuyết trò chơi vốn mơ hồ trở thành ngôn ngữ dễ hiểu và kết nối liền mạch với nghệ thuật tâm lý học; cho phép bạn nắm vững những bí ẩn của trò chơi tâm lý trong thời gian ngắn nhất.\r\n\r\nNhững kỹ năng trong Lý thuyết trò chơi có thể giúp chúng ta đọc thấu hoạt động tâm lý người khác, và từ đó chiếm thế chủ động trong trò chơi đấu trí giữa những người xung quanh.\r\n\r\nNhững trích dẫn hay:\r\n\r\n- Nếu coi một ván chơi như một trò chơi, mà trò chơi luôn luôn có thắng thua. Một bên thắng thì đồng nghĩa bên kia thất bại.\r\n\r\n- Đằng sau những người chiến thắng lẫy lừng đều che giấu một nỗi khổ tâm và chua xót của kẻ thua cuộc.\r\n\r\nHãy coi xã hội này như một ván cờ, mà mỗi chúng ta đều là những kỳ thủ. Từng đường đi nước bước của ta đều tương ứng với việc đặt từng con cờ. Một kỳ thủ tinh tường cẩn thận sẽ không hấp tấp đánh cờ, họ thường thông qua việc suy đoán lẫn nhau, thậm chí tính kế để từng bước đi đều khống chế đối phương cho đến khi giành được thắng lợi cuối cùng. Mà thuyết trò chơi chính là cuốn sách giáo khoa dạy những kỳ thủ chúng ta nên đánh cờ như thế nào.\r\n\r\nMã hàng	8936066697088\r\nTên Nhà Cung Cấp	1980 Books\r\nTác giả	Trần Phách Hàm\r\nNgười Dịch	Vu Vũ\r\nNXB	Dân Trí\r\nNăm XB	2023\r\nNgôn Ngữ	Tiếng Việt\r\nTrọng lượng (gr)	340\r\nKích Thước Bao Bì	20.5 x 13 x 1.6 cm\r\nSố trang	320\r\nHình thức	Bìa Mềm\r\nSản phẩm bán chạy nhất	Top 100 sản phẩm Tâm lý bán chạy của tháng\r\nGiá sản phẩm trên Fahasa.com đã bao gồm thuế theo luật hiện hành. Bên cạnh đó, tuỳ vào loại sản phẩm, hình thức và địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như Phụ phí đóng gói, phí vận chuyển, phụ phí hàng cồng kềnh,...\r\nChính sách khuyến mãi trên Fahasa.com không áp dụng cho Hệ thống Nhà sách Fahasa trên toàn quốc\r\nLý Thuyết Trò Chơi\r\n\r\nĐời người giống như trò chơi, mỗi bước đều phải cân nhắc xem đi như thế nào, đi về đâu, phải kết hợp nhiều yếu tố lại chúng ta mới có thể đưa ra được lựa chọn. Mà trong quá trình chọn lựa này các yếu tố khiến ta phải cân nhắc và những đường đi khác nhau sẽ ảnh hưởng trực tiếp đến kết quả.\r\n\r\nCuốn sách Lý thuyết trò chơi là bách khoa toàn thư về tâm lý học, về tẩy não và chống lại tẩy não, thao túng và chống lại thao túng, thống trị và chống lại thống trị. Cuốn sách giới thiệu công thức chiến thắng cho những “trò chơi” đấu trí giữa người với người trong cuộc sống hằng ngày; phân tách các khái niệm lý thuyết trò chơi vốn mơ hồ trở thành ngôn ngữ dễ hiểu và kết nối liền mạch với nghệ thuật tâm lý học; cho phép bạn nắm vững những bí ẩn của trò chơi tâm lý trong thời gian ngắn nhất.\r\n\r\nNhững kỹ năng trong Lý thuyết trò chơi có thể giúp chúng ta đọc thấu hoạt động tâm lý người khác, và từ đó chiếm thế chủ động trong trò chơi đấu trí giữa những người xung quanh."', '2023-12-11 16:21:15', 320, 'Bìa cứng\r\n', 100, 179000, 'Tiếng Việt\r\n', 1, 3, 4, 10, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(5, 'Tư Duy Chiến Lược - Lý Thuyết Trò Chơi Thực Hành', '5.jpg', '"Tư duy chiến lược là nghệ thuật vượt qua đối thủ cạnh tranh, với nhận thức rằng họ cũng đang cố gắng vượt qua mình. Mỗi chúng ta đều phải áp dụng tư duy chiến lược, theo cách này hay cách khác, tại nơi làm việc và ngay cả ở nhà. Thương gia và các doanh nghiệp sử dụng các chiến lược cạnh tranh phù hợp để tồn tại. Những huấn luyện viên bóng đá vạch ra các kế hoạch chiến lược để các cầu thủ tiến hành trên sân bóng. Các bậc cha mẹ muốn giáo dục con cái cũng phải trở thành những nhà chiến lược nghiệp dư.\r\n\r\nTư duy chiến lược đúng đắn trong nhiều hoàn cảnh khác nhau vẫn luôn là một nghệ thuật. Nhưng nền tảng của nó được xây dựng trên một số nguyên tắc cơ bản – một khoa học về chiến lược. Sau khi đọc cuốn sách này, người đọc từ các lĩnh vực nghề nghiệp khác nhau có thể trở thành những nhà chiến lược giỏi hơn nếu họ biết được những nguyên tắc này.\r\n\r\nTư duy chiến lược đã mang đến cho nhiều người một cách nhìn mới về mọi sự kiện, hiện tượng trong xã hội, kể từ văn học, phim ảnh và thể thao cho đến các sự kiện chính trị, lịch sử.\r\n\r\nTrong Tư duy chiến lược – Lý thuyết trò chơi thực hành của Avinash K. Dixit và Barry J. Nalebuff, các tác giả trình bày cho nhiều ví dụ minh họa từ những lĩnh vực khác nhau cho mỗi nguyên tắc cơ bản. Người đọc từ nhiều lĩnh vực khác nhau sẽ tìm thấy sự chia sẻ ở đây. Bạn cũng sẽ thấy cách thức mà những nguyên lý cơ bản giống nhau tạo ra chiến lược trong những hoàn cảnh khác nhau; hy vọng mang lại những góc nhìn mới về nhiều sự kiện đã và đang xảy ra.\r\n\r\nKhông hề khô khan như nhiều cuốn sách mang nặng tính học thuyết khác, Tư duy chiến lược diễn biến theo kiểu kể chuyện. Nguồn gốc xưa của nó là một khóa học về ""trò chơi chiến lược” mà Avinash Dixit triển khai và dạy tại Trường Woodrow Wilson về Các vấn đề cộng đồng và quốc tế thuộc Đại học Princeton. Barry J.Nalebuff sau đó dạy khóa học này, và dạy một khóa học tương tự ở khoa Khoa học ch.ính trị của Đại học Yale và sau đó là tại Trường Tổ chức và Quản trị (SOM) thuộc Đại học Yale.\r\n\r\nĐến nay, Tư duy chiến lược - Lý thuyết trò chơi thực hành đã trở thành cẩm nang quen thuộc của nhiều người, nhờ vào tính đúng đắn và khả năng ứng dụng cao trong thực tiễn đời sống của nó. “Tư duy chiến lược, đừng cạnh tranh khi không có nó”\r\n\r\nMã hàng	9786043857870\r\nTên Nhà Cung Cấp	Bách Việt\r\nTác giả	Avinash K. Dixit, Barry J. Nalebuff\r\nNgười Dịch	Nguyễn Tiến Dũng, Lê Ngọc Liên\r\nNXB	Dân Trí\r\nNăm XB	2023\r\nNgôn Ngữ	Tiếng Việt\r\nTrọng lượng (gr)	560\r\nKích Thước Bao Bì	20.5 x 14.5 x 2.7 cm\r\nSố trang	544\r\nHình thức	Bìa Mềm\r\nSản phẩm bán chạy nhất	Top 100 sản phẩm Nhân vật - Bài Học Kinh doanh bán chạy của tháng\r\nGiá sản phẩm trên Fahasa.com đã bao gồm thuế theo luật hiện hành. Bên cạnh đó, tuỳ vào loại sản phẩm, hình thức và địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như Phụ phí đóng gói, phí vận chuyển, phụ phí hàng cồng kềnh,...\r\nChính sách khuyến mãi trên Fahasa.com không áp dụng cho Hệ thống Nhà sách Fahasa trên toàn quốc\r\nTư Duy Chiến Lược - Lý Thuyết Trò Chơi Thực Hành\r\n\r\nTư duy chiến lược là nghệ thuật vượt qua đối thủ cạnh tranh, với nhận thức rằng họ cũng đang cố gắng vượt qua mình. Mỗi chúng ta đều phải áp dụng tư duy chiến lược, theo cách này hay cách khác, tại nơi làm việc và ngay cả ở nhà. Thương gia và các doanh nghiệp sử dụng các chiến lược cạnh tranh phù hợp để tồn tại. Những huấn luyện viên bóng đá vạch ra các kế hoạch chiến lược để các cầu thủ tiến hành trên sân bóng. Các bậc cha mẹ muốn giáo dục con cái cũng phải trở thành những nhà chiến lược nghiệp dư.\r\n\r\nTư duy chiến lược đúng đắn trong nhiều hoàn cảnh khác nhau vẫn luôn là một nghệ thuật. Nhưng nền tảng của nó được xây dựng trên một số nguyên tắc cơ bản – một khoa học về chiến lược. Sau khi đọc cuốn sách này, người đọc từ các lĩnh vực nghề nghiệp khác nhau có thể trở thành những nhà chiến lược giỏi hơn nếu họ biết được những nguyên tắc này.\r\n\r\nTư duy chiến lược đã mang đến cho nhiều người một cách nhìn mới về mọi sự kiện, hiện tượng trong xã hội, kể từ văn học, phim ảnh và thể thao cho đến các sự kiện chính trị, lịch sử.\r\n\r\nTrong Tư duy chiến lược – Lý thuyết trò chơi thực hành của Avinash K. Dixit và Barry J. Nalebuff, các tác giả trình bày cho nhiều ví dụ minh họa từ những lĩnh vực khác nhau cho mỗi nguyên tắc cơ bản. Người đọc từ nhiều lĩnh vực khác nhau sẽ tìm thấy sự chia sẻ ở đây. Bạn cũng sẽ thấy cách thức mà những nguyên lý cơ bản giống nhau tạo ra chiến lược trong những hoàn cảnh khác nhau; hy vọng mang lại những góc nhìn mới về nhiều sự kiện đã và đang xảy ra.\r\n\r\nKhông hề khô khan như nhiều cuốn sách mang nặng tính học thuyết khác, Tư duy chiến lược diễn biến theo kiểu kể chuyện. Nguồn gốc xưa của nó là một khóa học về ""trò chơi chiến lược” mà Avinash Dixit triển khai và dạy tại Trường Woodrow Wilson về Các vấn đề cộng đồng và quốc tế thuộc Đại học Princeton. Barry J.Nalebuff sau đó dạy khóa học này, và dạy một khóa học tương tự ở khoa Khoa học ch.ính trị của Đại học Yale và sau đó là tại Trường Tổ chức và Quản trị (SOM) thuộc Đại học Yale.\r\n\r\nĐến nay, Tư duy chiến lược - Lý thuyết trò chơi thực hành đã trở thành cẩm nang quen thuộc của nhiều người, nhờ vào tính đúng đắn và khả năng ứng dụng cao trong thực tiễn đời sống của nó. “Tư duy chiến lược, đừng cạnh tranh khi không có nó”"', '2023-12-11 16:21:15', 544, 'Bìa cứng\r\n', 100, 186000, 'Tiếng Việt\r\n', 2, 3, 2, 12, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(6, 'Bí Mật Tư Duy Triệu Phú (Tái Bản 2021)', '6.jpg', '"Trong cuốn sách này T. Harv Eker sẽ tiết lộ những bí mật tại sao một số người lại đạt được những thành công vượt bậc, được số phận ban cho cuộc sống sung túc, giàu có, trong khi một số người khác phải chật vật, vất vả mới có một cuộc sống qua ngày. Bạn sẽ hiểu được nguồn gốc sự thật và những yếu tố quyết định thành công, thất bại để rồi áp dụng, thay đổi cách suy nghĩ, lên kế hoạch rồi tìm ra cách làm việc, đầu tư, sử dụng nguồn tài chính của bạn theo hướng hiệu quả nhất.\r\n\r\nCuốn sách dành cho những ai còn loay hoay muốn tìm đường đến sự giàu có và thành công. “Bí mật tự duy triệu phú” mang đến nhiều tư duy mới cho người đọc về cách suy nghĩ của người giàu hay cách suy nghĩ để trở nên giàu có."', '2023-12-11 16:21:15', 287, 'Bìa mềm\r\n\r\n', 100, 108000, 'Tiếng Việt\r\n', 2, 1, 5, 3, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(7, 'Bờ Vai Nghiêng Nắng', '7.jpg', '"TỪ.KẾ.TƯỜNG - người từng được xem là ""ảo thuật gia"" ngôn ngữ tuổi mới lớn - trở lại văn đàn qua Tủ sách Tuổi Ngọc với cuốn sách “BỜ VAI NGHIÊNG NẮNG”.\r\n\r\nNhững tác phẩm viết cho tuổi mới lớn của Từ Kế Tường là những tác phẩm không phải chỉ của một thời. Đó là tình bạn, tình yêu của tuổi thanh xuân mới chớm nở; đó là không khí học đường với thầy cô, trường lớp; đó là những niềm vui, nỗi buồn của những người đang đứng trước ngưỡng cửa cuộc đời; đó là tình cảm gia đình, người thân… Độc giả của Từ Kế Tường do vậy là độc giả của nhiều thế hệ. Họ là những độc giả nhỏ tuổi cùng thời với Từ Kế Tường khi nhà văn mới bắt đầu sáng tác, nay đã lên tuổi ông bà. Họ là những người đã đọc tác phẩm Từ Kế Tường qua những lần tái bản sau năm 1975, nay đã ở tuổi phụ huynh. Và cùng với sự ra mắt của tủ sách Tuổi Ngọc, tái bản lại những tác phẩm của nhà văn, thì Từ Kế Tường lại tiếp tục có những độc giả trẻ trung thuộc thế hệ mới.\r\n\r\nVà như thế, mong rằng nhà văn Từ Kế Tường lại thêm một lần mang những tác phẩm quay lại văn đàn với những thành công mới trong sự đón nhận của độc giả nhiểu thế hệ.\r\n\r"', '2023-12-11 16:21:15', 218, 'Bìa mềm\r\n\r\n', 100, 120000, 'Tiếng Việt\r\n', 3, 4, 6, 1, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(8, 'Dị Bản', '8.jpg', 'Tác giả không chỉ viết một câu chuyện về tình yêu tình thân và sự mất mát - những điều tất yếu mà bất cứ ai cũng phải trải qua, cũng như cô đơn là cái giá mà con người phải trả khi trưởng thành. Đây còn là một câu chuyện về vai trò và trách nhiệm của con người với thế giới mình đang sống. Tác giả dẫn dắt chúng ta đối diện với những thách thức, hệ lụy của thế giới hiện đại như chiến tranh, môi trường, sự phát triển của trí tuệ nhân tạo…', '2023-12-11 16:21:15', 244, 'Bìa mềm\r\n\r\n', 100, 95000, 'Tiếng Anh\r\n', 3, 5, 7, 20, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(9, 'Nhật Ký Người Lạ', '9.jpg', '"Clare Cassidy là giáo viên dạy Văn của trường trung học Talgarth, tại đây, một đồng nghiệp và người bạn thân thiết của cô vừa bị sát hại. Hung thủ để lại ở hiện trường mảnh giấy với câu trích dẫn bí hiểm trong Người lạ, truyện ngắn kinh dị mang phong cách Gothic và cũng là tác phẩm yêu thích của Clare. Không chỉ vậy, thủ pháp gây án còn có sự trùng hợp lạ lùng với câu chuyện kia. Mục đích của hung thủ là gì, vì sao Người lạ hết lần này đến lần khác xuất hiện cùng những cái chết liên tiếp xảy ra, càng lúc càng lộ rõ một mối liên kết mật thiết giữa kẻ thủ ác và chính bản thân Clare?\r\n\r\nQuan trọng hơn hết là, nếu quả thật câu chuyện đen tối ấy đang từ trang sách bước ra người đời thực, liệu cái kết bi thảm có thể được thay đổi trước khi quá muộn?"', '2023-12-11 16:21:15', 516, 'Bìa mềm\r\n\r\n', 100, 189000, 'Tiếng Việt\r\n', 3, 6, 8, 12, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(10, 'English Grammar in Use Book w Ans', '10.jpg', 'The world\'s best-selling grammar series for learners of English. English Grammar in Use Fourth edition is an updated version of the world\'s best-selling grammar title. It has a fresh, appealing new design and clear layout, with revised and updated examples, but retains all the key features of clarity and accessibility that have made the book popular with millions of learners and teachers around the world. This \'with answers\' version is ideal for self-study. ', '2023-12-11 16:21:15', 550, 'Bìa mềm\r\n\r\n', 100, 178000, 'Tiếng Anh\r\n', 4, 7, 9, 11, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(11, 'Oxford Learner’s Pocket Dictionary 4Ed', '11.jpg', 'Up-to-date vocabulary with new words from British and American English Oxford 3000(t) keywords (the most important words to learn in English) are marked with a key symbol Corpus-based examples show how words are used Lots of help with irregular forms and spelling Explains thousands of idioms and phrasal verbs', '2023-12-11 16:21:15', 528, 'Bìa mềm\r\n\r\n', 100, 85000, 'Tiếng Anh\r\n', 4, 8, 10, 10, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(12, 'Sapiens : A Brief History of Humankind', '12.jpg', '"#1 New York Times Bestseller\r\n\r\nThe Summer Reading Pick for President Barack Obama, Bill Gates, and Mark Zuckerberg, now available as a beautifully packaged paperback\r\n\r\nFrom a renowned historian comes a groundbreaking narrative of humanity\'s creation and evolution--a #1 international bestseller--that explores the ways in which biology and history have defined us and enhanced our understanding of what it means to be ""human.""\r\n\r\nOne hundred thousand years ago, at least six different species of humans inhabited Earth. Yet today there is only one--homo sapiens. What happened to the others? And what may happen to us?\r\n\r\nMost books about the history of humanity pursue either a historical or a biological approach, but Dr. Yuval Noah Harari breaks the mold with this highly original book that begins about 70,000 years ago with the appearance of modern cognition. From examining the role evolving humans have played in the global ecosystem to charting the rise of empires, Sapiens integrates history and science to reconsider accepted narratives, connect past developments with contemporary concerns, and examine specific events within the context of larger ideas.\r\n\r\nDr. Harari also compels us to look ahead, because over the last few decades humans have begun to bend laws of natural selection that have governed life for the past four billion years. We are acquiring the ability to design not only the world around us, but also ourselves. Where is this leading us, and what do we want to become?\r\n\r\nFeaturing 27 photographs, 6 maps, and 25 illustrations/diagrams, this provocative and insightful work is sure to spark debate and is essential reading for aficionados of Jared Diamond, James Gleick, Matt Ridley, Robert Wright, and Sharon Moalem.\r\n\r\nMã hàng	9780062316110\r\nTên Nhà Cung Cấp	HarperCollins Publishers\r\nTác giả	Yuval Noah Harari\r\nNXB	Harper Perennial\r\nNăm XB	2018\r\nTrọng lượng (gr)	360\r\nKích Thước Bao Bì	15.2 x 2.8 x 22.9 cm\r\nSố trang	464\r\nHình thức	Bìa Mềm\r\nSản phẩm hiển thị trong	\r\nHarperCollins Publishers\r\nSản phẩm bán chạy nhất	Top 100 sản phẩm General & World History bán chạy của tháng\r\nGiá sản phẩm trên Fahasa.com đã bao gồm thuế theo luật hiện hành. Bên cạnh đó, tuỳ vào loại sản phẩm, hình thức và địa chỉ giao hàng mà có thể phát sinh thêm chi phí khác như Phụ phí đóng gói, phí vận chuyển, phụ phí hàng cồng kềnh,...\r\nChính sách khuyến mãi trên Fahasa.com không áp dụng cho Hệ thống Nhà sách Fahasa trên toàn quốc\r\n#1 New York Times Bestseller\r\n\r\nThe Summer Reading Pick for President Barack Obama, Bill Gates, and Mark Zuckerberg, now available as a beautifully packaged paperback\r\n\r\nFrom a renowned historian comes a groundbreaking narrative of humanity\'s creation and evolution--a #1 international bestseller--that explores the ways in which biology and history have defined us and enhanced our understanding of what it means to be ""human.""\r\n\r\nOne hundred thousand years ago, at least six different species of humans inhabited Earth. Yet today there is only one--homo sapiens. What happened to the others? And what may happen to us?\r\n\r\nMost books about the history of humanity pursue either a historical or a biological approach, but Dr. Yuval Noah Harari breaks the mold with this highly original book that begins about 70,000 years ago with the appearance of modern cognition. From examining the role evolving humans have played in the global ecosystem to charting the rise of empires, Sapiens integrates history and science to reconsider accepted narratives, connect past developments with contemporary concerns, and examine specific events within the context of larger ideas.\r\n\r\nDr. Harari also compels us to look ahead, because over the last few decades humans have begun to bend laws of natural selection that have governed life for the past four billion years. We are acquiring the ability to design not only the world around us, but also ourselves. Where is this leading us, and what do we want to become?\r\n\r\nFeaturing 27 photographs, 6 maps, and 25 illustrations/diagrams, this provocative and insightful work is sure to spark debate and is essential reading for aficionados of Jared Diamond, James Gleick, Matt Ridley, Robert Wright, and Sharon Moalem."', '2023-12-11 16:21:15', 512, 'Bìa mềm\r\n\r\n', 100, 354000, 'Tiếng Anh\r\n', 4, 9, 11, 10, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(13, 'Nuôi Dạy Bé Trai Từ 0 - 6 Tuổi (Tái Bản 2021)', '13.jpg', '"Tác giả của cuốn sách Nuôi dạy bé trai từ 0 – 6 tuổi là người đã có 20 năm nghiên cứu về sự trưởng thành của trẻ em, quan sát 12.000 trẻ ở nhiều độ tuổi khác nhau, từ em bé sơ sinh cho đến sinh viên đại học. Từ kinh nghiệm thực tiễn và nghiên cứu tác giả đã đúc kết được những điều quan trọng đối với sự phát triển của trẻ rằng:\n\nNgay từ khi sinh ra, giữa bé trai và bé gái đã có những đặc trưng khác nhau cả về não bộ cũng như hệ thần kinh vận động. Do vậy cách giáo dục cũng sẽ khác nhau. Nếu nắm được điểm mấu chốt trong cách nuôi dạy cho từng bé thì bố mẹ có thể phát triển năng lực của trẻ một cách toàn diện."', '2023-12-11 16:21:15', 216, 'Bìa mềm\r\n\r\n', 100, 69000, 'Tiếng Việt\r\n', 5, 2, 12, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(14, 'Nuôi Dạy Bé Gái Từ 0 Đến 6 Tuổi (Tái Bản 2020)', '14.jpg', '"Tác giả của cuốn sách Nuôi dạy bé gái từ 0 – 6 tuổi là người đã có 20 năm nghiên cứu về sự trưởng thành của trẻ em, quan sát 12.000 trẻ ở nhiều độ tuổi khác nhau, từ em bé sơ sinh cho đến sinh viên đại học. Từ kinh nghiệm thực tiễn và nghiên cứu tác giả đã đúc kết được những điều quan trọng đối với sự phát triển của trẻ rằng:\n\nNgay từ khi sinh ra, giữa bé trai và bé gái đã có những đặc trưng khác nhau cả về não bộ cũng như hệ thần kinh vận động. Do vậy cách giáo dục cũng sẽ khác nhau. Nếu nắm được điểm mấu chốt trong cách nuôi dạy cho từng bé thì bố mẹ có thể phát triển năng lực của trẻ một cách toàn diện."', '2023-12-11 16:21:15', 236, 'Bìa mềm\r\n\r\n', 100, 75000, 'Tiếng Việt\r\n', 5, 2, 12, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(15, 'Yêu Thương, Khen Ngợi Và Nhìn Nhận - Bí Quyết Nuôi Dạy Con Theo Phương Pháp Shichida (Tái Bản 2021)', '15.jpg', 'Phương pháp Shichida là phương pháp giáo dục nổi tiếng tại Nhật Bản, nhằm khơi dậy mọi tiềm năng bẩm sinh của trẻ. Đây là phương pháp giáo dục sớm đến từ Nhật Bản dựa trên sự phát triển não bộ của trẻ từ 0 đến 6 tuổi. Phương pháp Shichida đã được phát triển dựa trên nền tảng khoa học và chứng thực về não phải, cân bằng phát triển hai bán cầu não. Từ đó, khả năng của trẻ không chỉ dừng lại ở các kỹ năng cơ bản như đọc, toán, nhạc, họa… mà qua đó phát triển hình thành tính cách, năng lực tư duy, tình yêu và sự gắn kết giữa cha mẹ và con cái.', '2023-12-11 16:21:15', 176, 'Bìa mềm\r\n\r\n', 100, 94000, 'Tiếng Việt\r\n', 5, 10, 13, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(16, 'Hoàng Tử Bé (Song Ngữ Việt-Anh)', '16.jpg', '"Hoàng tử bé được xuất bản lần đầu năm 1943 của nhà văn, phi công người Pháp Antoine de Saint-exupéry là một trong những cuốn tiểu thuyết kinh điển nổi tiếng nhất mọi thời đại. Câu chuyện ngắn gọn về cuộc gặp gỡ diệu kỳ giữa viên phi công bị rơi máy bay và Hoàng tử bé giữa sa mạc Sa-ha-ra hoang vu. Hành tinh quê hương và các mối quan hệ của hoàng tử bé dần hé lộ: Tình bạn, tình yêu thương của Hoàng tử bé dành cho bông hồng duy nhất, tình cảm sâu sắc dành cho chú cáo.\r\nKhông những vậy, thông qua các cuộc gặp gỡ trong chuyến du ngoạn tới các hành tinh khác nhau của hoàng tử bé cũng chứa đựng triết lý nhân sinh sâu sắc về các kiểu người trong xã hội hiện đại.\r\nThật không ngoa khi khẳng định, mỗi câu chữ trong cuốn sách này đều đầy triết lý và mỗi người, mỗi lứa tuổi và mỗi hoàn cảnh khi đọc sẽ có những cảm nhận riêng.\r\n"', '2023-12-11 16:21:15', 200, 'Bìa mềm\r\n\r\n', 100, 79000, 'Tiếng Việt\r\n', 6, 4, 14, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(17, 'Dế Mèn Phiêu Lưu Ký - Tái Bản 2020', '17.jpg', '"Ấn bản minh họa màu đặc biệt của Dế Mèn phiêu lưu ký, với phần tranh ruột được in hai màu xanh - đen ấn tượng, gợi không khí đồng thoại.\r\n\r\n“Một con dế đã từ tay ông thả ra chu du thế giới tìm những điều tốt đẹp cho loài người. Và con dế ấy đã mang tên tuổi ông đi cùng trên những chặng đường phiêu lưu đến với cộng đồng những con vật trong văn học thế giới, đến với những xứ sở thiên nhiên và văn hóa của các quốc gia khác. Dế Mèn Tô Hoài đã lại sinh ra Tô Hoài Dế Mèn, một nhà văn trẻ mãi không già trong văn chương...” - Nhà phê bình Phạm Xuân Nguyên\r\n\r\n“Ông rất hiểu tư duy trẻ thơ, kể với chúng theo cách nghĩ của chúng, lí giải sự vật theo lô gích của trẻ. Hơn thế, với biệt tài miêu tả loài vật, Tô Hoài dựng lên một thế giới gần gũi với trẻ thơ. Khi cần, ông biết đem vào chất du ký khiến cho độc giả nhỏ tuổi vừa hồi hộp theo dõi, vừa thích thú khám phá.” - TS Nguyễn Đăng Điệp\r\n"', '2023-12-11 16:21:15', 180, 'Bìa mềm\r\n\r\n', 100, 50000, 'Tiếng Việt\r\n', 6, 11, 15, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(18, 'Cái Tết Của Mèo Con (Tái Bản 2019)', '18.jpg', '"Mèo con mới về nhà, đêm đầu tiên đã giáp mặt lão Chuột cống dữ dằn cùng lũ chuột nhắt hung hăng. Mèo con khiếp sợ, nhưng vốn là một chú mèo dũng cảm, Mèo con bắt đầu học hỏi, can đảm đánh nhau với rắn hổ mang.\r\n\r\nKhông những thế, Mèo con còn truyền lòng quả cảm của mình cho cả bác Nồi đồng và chị Chổi. Họ đã cùng nhau đánh bại lão Chuột cống hung ác và đám chuột nhắt.\r\n\r\n“Cái Tết của Mèo con” là bài học về lòng quả cảm và tinh thần đoàn kết. Câu chuyện mang đến thông điệp cho các bạn nhỏ của chúng ta: Lòng dũng cảm là một phẩm chất, được hình thành khi ta rèn luyện mỗi ngày.\r\n\r\nRa đời cách nay hơn nửa thế kỉ, tác phẩm của nhà văn Nguyễn Đình Thi đã chinh phục bao thế hệ độc giả nhỏ tuổi.\r\n\r\nẤn bản lần này có những tranh minh họa màu vô cùng sống động của họa sĩ trẻ Thùy Dung."', '2023-12-11 16:21:15', 44, 'Bìa mềm\r\n\r\n', 100, 45000, 'Tiếng Việt\r\n', 6, 11, 16, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(19, 'Cánh Cửa Mở Rộng - Phải Trái Đúng Sai', '19.jpg', '"Phải Trái Đúng Sai là quyển sách best-seller tại Mỹ của giáo sư Michael Sandel, đại học Harvard.\r\n\r\nSách bàn về vấn đề đạo đức dưới cái nhìn triết học. Tác giả đưa ra các vụ việc gây tranh cãi về vấn đề đạo đức để mổ xẻ dưới nhiều góc độ, theo quan điểm của các học thuyết triết học khác nhau, mỗi chương trình bày sâu về một học thuyết. Nhờ vậy, tư tưởng của Aristotle, Jeremy Bentham, Immanuel Kant, John Stuart Mill, Robert Nozick, và John Rawl được trình bày với sự rõ ràng và gần gũi, mà theo New York Times là ""hiếm khi được giải thích dễ hiểu đến như vậy"".\r\n\r\nNhững lời bình\r\n\r\n""Michael Sandel – có lẽ là giáo sư đại học nổi tiếng nhất ở Mỹ - đã mang lại “sự minh bạch về đạo đức cho sự lựa chọn mà chúng ta phải đối mặt, với tư cách là công dân trong xã hội dân chủ"". Ông đã chỉ ra rằng sự chia rẽ chính trị không phải giữa cánh tả với cánh hữu mà giữa những người nhận ra không có gì quý hơn quyền cá nhân và lựa chọn cá nhân với những người tin vào một nền chính trị phục vụ lợi ích số đông."" - Bưu điện Washington\r\n\r\n""Quyết liệt, dễ hiểu, và đầy tính nhân văn, cuốn sách này thực sự là một cuốn sách làm thay đổi người đọc."" - Publisher Weekly\r\n\r\nCuốn sách thuộc Tủ sách Cánh Cửa Mở Rộng - Tủ sách hợp tác giữa nhà toán học Ngô Bảo Châu và nhà văn Phan Việt với Nhà xuất bản Trẻ."', '2023-12-11 16:21:15', 404, 'Bìa mềm\r\n\r\n', 100, 155000, 'Tiếng Việt\r\n', 7, 5, 17, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(20, 'Đứa Trẻ Hiểu Chuyện Thường Không Có Kẹo Ăn', '20.jpg', '"“Đứa trẻ hiểu chuyện thường không có kẹo ăn” – Cuốn sách dành cho những thời thơ ấu đầy vết thương.\n\nTrên đời này có một điều rất kỳ diệu, đó là bậc phụ huynh nào cũng mong muốn con mình trở nên hoàn hảo theo một hình mẫu giống hệt nhau.\n\nLanh lẹ, khôn khéo, dễ thương, luôn nhìn cha mẹ với gương mặt tươi cười trong sáng.\n\nKhi người lớn yêu cầu chúng làm gì đó, chúng sẽ vui vẻ làm theo. Không phàn nàn, không oán trách, không cáu gắt, lại càng không phản kháng cãi cự.\n\nNhững khi cha mẹ mệt mỏi hay chán chường, chúng sẽ rúc vào lòng cha mẹ như một chú chim nhỏ, giúp họ giải tỏa ưu tư phiền muộn.\n\nThậm chí ngay cả khi cha mẹ cáu giận, đối xử bất công với chúng, chúng cũng phải nhanh chóng tha thứ, dịu dàng an ủi ngược lại cha mẹ.\n\nChúng chẳng khác nào một con búp bê phó mặc hoàn toàn cho người khác sắp xếp. Thà bản thân chịu thiệt cũng không để cha mẹ buồn lòng.\n\nNhưng bạn biết không, đằng sau những đứa trẻ hiểu chuyện ngoan ngoãn trong mơ ấy, hóa ra lại toàn là sự tổn thương. Chúng không muốn tổn thương người khác, vì vậy chúng lựa chọn tổn thương chính mình.\n\nMà chúng làm tất cả những điều đó chỉ đơn giản là vì yêu thương cha mẹ mình mà thôi.\n\nNếu bạn cũng từng là một đứa trẻ như thế, từng phải hạ thấp bản thân, từng buộc phải nhường nhịn người khác, từng phải học cách nhận biết sắc mặt từ khi còn quá nhỏ… thì nhất định đừng bỏ qua cuốn sách “Đứa trẻ hiểu chuyện thường không có kẹo ăn” của tác giả Nguyên Anh.\n\nVới tư cách cố vấn cấp hai quốc gia, Nguyên Anh đã từng là người tìm cách chữa lành vết thương cho hàng nghìn tâm hồn mang theo tổn thương thời thơ ấu. Từng câu, từng chữ bà viết nên đều xuất phát từ những câu chuyện hoàn toàn có thật.\n\nCó thể sau khi đọc xong, những vết thương của bạn vẫn sẽ chẳng thể lành lại vĩnh viễn, nhưng chỉ cần bạn cảm thấy ổn hơn một chút, như vậy là đủ rồi."', '2023-12-11 16:21:15', 368, 'Bìa cứng\r\n', 100, 148000, 'Tiếng Việt\r\n', 7, 4, 18, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(21, 'Sang Chấn Tâm Lý - Hiểu Để Chữa Lành', '21.jpg', '"Hiện nay, chúng ta đã biết rằng sang chấn gây ra những thay đổi về sinh lý học trong cơ thể, những thứ giúp ta cảm nhận được mình đang sống. Những thay đổi này giải thích tại sao các cá nhân bị sang chấn trở nên nhạy cảm hơn đối với những hiểm họa ngay cả khi họ đang tham gia cuộc sống thường ngày. Chúng cũng giúp chúng ta hiểu được vì sao những người bị sang chấn thường liên tục lặp đi lặp lại những hành động nào đó. Chúng ta cũng đã biết những hành vi của người bị sang chấn không phải là hệ quả của việc sa sút về đạo đức, là dấu hiệu của việc mất lý trí hay nhân cách kém mà là do những thay đổi trong não bộ của họ.\r\n""Sang chấn tâm lý - Hiểu để chữa lành"" là một tác phẩm kinh điển của tâm thần học hiện đại, là một công trình khoa học công phu và nghiêm túc, trải rộng trên nhiều lĩnh vực - tâm lý học thần kinh, tâm lý học phát triển, tâm bệnh học, tâm lý trị liệu - được đúc kết sau nhiều năm kinh nghiệm làm việc của chính tác giả - Tiến sĩ Y khoa Bessel Van Der Kolk, và dựa trên những câu chuyện có thật của các bệnh nhân mà tác giả có dịp tiếp xúc hoặc chữa trị."', '2023-12-11 16:21:15', 572, 'Bìa cứng\r\n', 100, 350000, 'Tiếng Việt\r\n', 7, 10, 19, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(22, 'Bùi Kiến Thành - Người Mở Khóa Lãng Du', '22.jpg', '"Cánh cửa thời gian trở về lịch sử của dân tộc như được mở ra bởi câu chuyện về cuộc đời của một nhân vật gắn liền với sự đổi thay, chuyển mình của đất nước.\r\n\r\nBùi Kiến Thành - Một con người vừa góp phần làm nên lịch sử, vừa chứng kiến nhiều giai đoạn lịch sử quan trọng. Ông từng là:\r\n\r\n- Trợ lý đặc biệt cho Tổng thống Việt Nam Cộng hòa Ngô Đình Diệm\r\n\r\n- Đại diện cho Ngân hàng Quốc gia Việt Nam tại Mỹ\r\n\r\n- Tư vấn cho tiến trình ĐỔI MỚI và tiến trình BÌNH THƯỜNG HÓA QUAN HỆ NGOẠI GIAO VIỆT – MỸ\r\n\r\n- Cố vấn cho ba đời Thủ tướng nước Cộng hòa Xã hội Chủ nghĩa Việt Nam: Võ Văn Kiệt, Phan Văn Khải, Nguyễn Tấn Dũng\r\n\r\nNhưng đó mới chỉ là “bề nổi của tảng băng chìm” ở con người Bùi Kiến Thành. Bởi ẩn sâu bên trong một chuyên gia tài chính kinh tế, một chính khách, một nhà ngoại giao, một nhà văn hoá… lại là một tâm hồn phiêu du, lãng tử.  \r\n\r\nGiống như một bộ phim vừa kịch tính vừa êm ái trữ tình, cuốn hồi ký Bùi Kiến Thành – Người mở khóa lãng du đã khắc hoạ sinh động, rõ nét cuộc đời đầy thăng trầm của ông trong dòng chảy lịch sử đất nước suốt gần một thế kỷ qua. Ở đó, có máu và nước mắt của chiến tranh, có nỗi buồn đau của người “anh hùng ngã ngựa”, có đói nghèo của thời bao cấp, có cuộc sống tha hương nơi đất khách quê người,… Nhưng trên hết, đó là khát vọng sống, khát vọng cống hiến, khát vọng “mở khóa” những giai đoạn lịch sử khó khăn để mang lại hoà bình, thịnh vượng cho đất nước.\r\n\r\nMời bạn đọc lật giở từng trang sách để cùng “mở khóa” cuộc đời Bùi Kiến Thành!"', '2023-12-11 16:21:15', 356, 'Bìa cứng\r\n', 100, 150000, 'Tiếng Việt\r\n', 8, 10, 20, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(23, 'Cái Chết Của Nền Dân Chủ: Những Bước Tiến Quyền Lực Của Hitler', '23.jpg', '"Tại sao một nền dân chủ khai sáng như Cộng hòa Weimar lại mọc lên một chế độ tàn ác nhất trong lịch sử loài người? Tại sao một chính phủ dân chủ lại để một kẻ độc tài như Hitler nắm quyền? Có phải chủ nghĩa Quốc xã hình thành bởi vì quyền lực không được kiểm soát? Có phải chủ nghĩa Quốc xã là một vấn đề riêng biệt của nước Đức, hay là biểu hiện của một cuộc khủng hoảng rộng lớn hơn? Có phải sự trỗi dậy của Hitler là tất yếu hay nó chỉ là ngẫu nhiên? Tất cả sẽ được Benjamin Carter Hett giải đáp phần nào trong tựa sách: CÁI CHẾT CỦA NỀN DÂN CHỦ.\r\n\r\nCái Chết Của Nền Dân Chủ - Những Bước Tiến Quyền Lực Của Hitler (tựa gốc: The Death of Democracy: Hitler’s Rise to Power and The Downfall of The Weimar Republic) là tác phẩm biên khảo lịch sử của Benjamin Carter Hett, được xuất bản lần đầu năm 2018 và đã được dịch ra nhiều thứ tiếng.\r\n\r\nCộng hòa Weimar (Weimar Republic) là tên gọi không chính thức của nước Đức từ 1918 đến 1933, khi một nền dân chủ cộng hòa được thiết lập, nối giữa Đế chế Đức theo chế độ quân chủ lập hiến trước năm 1918 và Đế chế Đức theo chế độ độc tài Quốc xã từ năm 1933 (Đế chế thứ Ba, Đệ tam Đế chế). Tên gọi Cộng hòa Weimar được đặt theo tên của thị trấn Weimar, nơi Quốc hội lập hiến của Đức làm việc và soạn thảo bản hiến pháp Cộng hòa đầu tiên, gọi là Hiến pháp Weimar.\r\n\r\n------\r\n\r\n“Uyên bác, giàu thông tin...hấp dẫn. Hett cho chúng ta thấy bài học về sự mong manh của nền dân chủ và sự nguy hiểm của niềm tin tự mãn rằng các thể chế tự do sẽ luôn bảo vệ chúng ta.” – The Times.\r\n\r\n“Benjamin Carter Hett là một trong số ít các nhà sử học có khả năng suy nghĩ thấu đáo và biết cách kể một câu chuyện hay - mà không cần đơn giản hóa nó. Cuốn sách của ông đã giải quyết một trong những câu hỏi thú vị nhất lịch sử nước Đức: Làm thế nào mà một quốc gia có học thức và phát triển như Đức lại có thể rơi vào tay Adolf Hitler?” – Stefan Aust.\r\n\r\n“[Một] nghiên cứu cực kỳ xuất sắc về sự kết thúc của chế độ lập hiến ở Đức... Được viết cẩn thận cùng nền tảng kiến thức tốt, với các bản vẽ thu nhỏ chỉn chu về các cá nhân và các cuộc thảo luận ngắn gọn về thể chế và kinh tế... [Benjamin Carter Hett] đã mô tả một cách nhạy cảm về một cuộc khủng hoảng đạo đức trước một thảm họa đạo đức” – Timothy Snyder, The New York Times Book Review."', '2023-12-11 16:21:15', 362, 'Bìa cứng\r\n', 100, 278000, 'Tiếng Việt\r\n', 8, 2, 21, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(24, 'Bắc Hành Lược Ký', '24.jpg', '"Bắc hành lược ký là một “hồi ký chính trị” của Trường Phái hầu Lê Quýnh mà trọng điểm là mười năm ông bị cầm tù trong nhiều nhà ngục tại Trung Hoa sau khi theo vua Lê Chiêu Thống chạy sang phương Bắc lưu vong. Có thể xem nó như một phong vũ biểu đo lường gió mưa, thăng trầm của thời cuộc, phản ánh những lên xuống trong bang giao Thanh-Việt từ đời Quang Trung sang đời Cảnh Thịnh và sau cùng là đời Gia Long.\r\n\r\nBản dịch mới lần này dựa theo bản Hán văn của tạp chí Nam Phong, có đối chiếu, bổ túc, tham khảo các bản in trong Việt Nam Hán văn tiểu thuyết tùng san và lưu trữ tại Viện Hán Nôm Hà Nội, cùng những tài liệu, văn thư của triều Thanh trong cùng thời điểm, nhằm giúp bạn đọc có cái nhìn đa chiều, sáng tỏ hơn khi nghiên cứu về giai đoạn lịch sử từ cuối triều Lê đến đầu triều Nguyễn.\r\n\r"', '2023-12-11 16:21:15', 376, 'Bìa cứng\r\n', 100, 125000, 'Tiếng Việt\r\n', 8, 12, 22, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(25, 'Gió Ngừng Thổi, Tình Còn Vương', '25.jpg', '"Tình là thứ động lòng người nhất, nàng tên là Mạc Tình nhưng cả đời lại khổ vì tình.\r\n\r\nChàng tên là Tần Phong - Gió là thứ vô tình nhất nhưng lại vì tình mà dừng bước, cuối cùng tan biến trong không khí...\r\n\r\nNgười trong nhân thế đều biết tình ái nơi cõi trần là điều đau khổ nhưng có bao nhiêu người thực sự hiểu thấu được nó? Nếu đã bước vào hồng trần, chi bằng hãy dốc hết lòng mà yêu. Bất luận là tình sâu hay duyên mỏng, chỉ mong đời này không hối hận"', '2023-12-11 16:21:15', 304, 'Bìa mềm\r\n\r\n', 100, 89000, 'Tiếng Anh\r\n', 9, 4, 23, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(26, 'Rung Động Chỉ Vì Em', '26.jpg', '"Năm mười chín tuổi, bất chấp sự chênh lệch về gia cảnh, học vấn và địa vị xã hội, Tần Hiển và Tô Kiều vẫn say sưa chìm đắm trong mối tình đầu thuần khiết. Đáng tiếc thay, những tự ti, mặc cảm của tuổi trẻ đã khiến hai người bỏ lỡ nhau. Mải miết kiếm tìm, tám năm đau đáu một niềm hy vọng, cuối cùng ông trời cũng run rủi cho anh gặp lại cô. Vẫn là đôi mắt cong cong và nụ cười đẹp đến mê hồn. Tựa như năm xưa, lúc anh thấy cô đứng đợi ngoài cổng trường, lưng tựa vào tường, tươi cười nói với anh “Tôi mời cậu ăn khuya”, anh đã trúng tiếng sét ái tình với cô chính từ khoảnh khắc ấy.\r\nNụ cười của cô đã khiến anh chìm vào bể tình, khiến anh đau khổ, khiến anh khao khát, sẵn sàng trầm luân. Lần này, nếu anh lại bỏ lỡ thì không chỉ là tám năm, mà là một đời. Bởi, cả đời này, trái tim anh chỉ vì cô mà rung động."', '2023-12-11 16:21:15', 572, 'Bìa mềm\r\n\r\n', 100, 189000, 'Tiếng Việt\r\n', 9, 13, 24, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(27, 'Bến Xe (Tái Bản 2020)', '27.jpg', '"Thứ tôi có thể cho em trong cuộc đời này\r\n\r\nchỉ là danh dự trong sạch"', '2023-12-11 16:21:15', 284, 'Bìa mềm\r\n\r\n', 100, 89000, 'Tiếng Việt\r\n', 9, 4, 25, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(28, 'Tổng Ôn Ngữ Pháp Tiếng Anh (Tái Bản 2023)', '28.jpg', '"Nội Dung Sách:\r\n\r\n- Đầy đủ nhất với 30 CHUYÊN ĐỀ NGỮ PHÁP Trong Tiếng Anh của cô Trang Anh.\r\n- Dày 606 trang gần 7.000 bài tập - SỐ LƯỢNG BÀI NHIỀU NHẤT.\r\n- TỔNG ÔN TẬP ngữ pháp tiếng anh- CHẮC CHẮN CÓ trong đề thi.\r\n- Lý thuyết được đơn giản hoá, trình bày MINDMAP dễ hiểu và siêu dễ nhớ.\r\n- Mức độ bài tập đi từ CỰC DỄ đến KHÔNG THỂ KHÓ HƠN."', '2023-12-11 16:21:15', 608, 'Bìa mềm\r\n\r\n', 100, 200000, 'Tiếng Việt\r\n', 10, 14, 26, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(29, 'Bứt Phá Điểm Số Sat 2 Với 626 Bài Toán Khó', '29.jpg', 'BỨT PHÁ ĐIỂM SỐ SAT 2 VỚI 626 BÀI TOÁN KHÓ – Questions for the SAT Mathematics Level 2 Subject Test là cuốn sách gồm 626 bài Toán luyện thi dành cho học sinh trung học phổ thông sẽ tham gia kì thi SAT Mathematics Level 2 Subject Test, nhằm ứng tuyển vào nhóm các trường kỹ thuật (cao đẳng và đại học) tại Mỹ. Cuốn sách sẽ hỗ trợ các bạn học sinh có một hồ sơ ứng tuyển hiệu quả với điểm số SAT Mathematics Level 2 Subject Test khả quan nhất.', '2023-12-11 16:21:15', 248, 'Bìa mềm\r\n\r\n', 100, 149000, 'Tiếng Việt\r\n', 10, 15, 27, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51'),
	(30, 'Phương Pháp Giải Các Dạng Toán THPT - Phương Pháp Tọa Độ Trong Không Gian', '30.jpg', 'Bộ sách PHƯƠNG PHÁP GIẢI CÁC DẠNG TOÁN THPT là tài liệu tham khảo chuyên sâu để cung cấp cho các thầy giáo, cô giáo và các em học sinh các bài giảng để hoàn thiện rồi nâng cao kiến thức. Từ đó, hướng tới những sáng tạo trong học tập cũng như trong cuộc sống.', '2023-12-11 16:21:15', 284, 'Bìa cứng\r\n', 100, 133000, 'Tiếng Việt\r\n', 10, 16, 28, 0, 0, '2023-12-11 16:22:50', '2023-12-11 16:22:51');

-- Dumping structure for table bookstore.bookdetail
CREATE TABLE IF NOT EXISTS `bookdetail` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Barcode` int DEFAULT NULL,
  `Price` double NOT NULL,
  `Quantity` int DEFAULT '0',
  `IsSold` tinyint DEFAULT '0',
  `BookId` int DEFAULT NULL,
  `DiscountId` int DEFAULT NULL,
  `SupplierId` int DEFAULT NULL,
  `IsDeleted` tinyint NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_BookDetail_BookId` (`BookId`),
  KEY `IX_BookDetail_DiscountId` (`DiscountId`),
  KEY `IX_BookDetail_SupplierId` (`SupplierId`),
  CONSTRAINT `FK_BookDetail_Book_BookId` FOREIGN KEY (`BookId`) REFERENCES `book` (`Id`),
  CONSTRAINT `FK_BookDetail_Discount_DiscountId` FOREIGN KEY (`DiscountId`) REFERENCES `discount` (`Id`),
  CONSTRAINT `FK_BookDetail_Supplier_SupplierId` FOREIGN KEY (`SupplierId`) REFERENCES `supplier` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table bookstore.bookdetail: ~31 rows (approximately)
INSERT INTO `bookdetail` (`Id`, `Barcode`, `Price`, `Quantity`, `IsSold`, `BookId`, `DiscountId`, `SupplierId`, `IsDeleted`, `CreatedAt`, `UpdatedAt`) VALUES
	(1, 10000001, 248000, 0, 0, 1, 1, 1, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(2, 10000002, 239000, 3, 0, 2, 2, 21, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(3, 10000003, 158000, 2, 0, 3, 1, 1, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(4, 10000004, 179000, 5, 0, 4, 4, 2, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(5, 10000005, 186000, 5, 0, 5, 5, 3, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(6, 10000006, 108000, 5, 0, 6, 6, 1, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(7, 10000007, 120000, 5, 0, 7, 7, 4, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(8, 10000008, 95000, 4, 0, 8, 8, 5, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(9, 10000009, 189000, 5, 0, 9, 9, 6, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(10, 10000010, 178000, 5, 0, 10, 10, 7, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(11, 10000011, 85000, 5, 0, 11, 11, 8, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(12, 10000012, 354000, 5, 0, 12, 12, 9, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(13, 10000013, 69000, 4, 0, 13, 13, 10, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(14, 10000014, 75000, 5, 0, 14, 14, 10, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(15, 10000015, 94000, 5, 0, 15, 15, 1, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(16, 10000016, 79000, 5, 0, 16, 16, 11, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(17, 10000017, 50000, 5, 0, 17, 17, 12, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(18, 10000018, 45000, 5, 0, 18, 18, 12, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(19, 10000019, 155000, 5, 0, 19, 19, 5, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(20, 10000020, 148000, 5, 0, 20, 20, 13, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(21, 10000021, 350000, 5, 0, 21, 2, 14, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(22, 10000022, 150000, 5, 0, 22, 3, 15, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(23, 10000023, 278000, 5, 0, 23, 4, 16, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(24, 10000024, 125000, 5, 0, 24, 5, 17, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(25, 10000025, 89000, 5, 0, 25, 6, 6, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(26, 10000026, 189000, 5, 0, 26, 7, 6, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(27, 10000027, 89000, 5, 0, 27, 2, 6, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(28, 10000028, 200000, 5, 0, 28, 8, 20, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(29, 10000029, 149000, 5, 0, 29, 9, 18, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(30, 10000030, 133000, 5, 0, 30, 1, 19, 0, '2023-12-11 16:14:52', '2023-12-11 16:14:53'),
	(31, 10000031, 0, 0, 0, 1, NULL, 3, 0, '0001-01-01 00:00:00', '0001-01-01 00:00:00');

-- Dumping structure for table bookstore.category
CREATE TABLE IF NOT EXISTS `category` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext,
  `IsDeleted` tinyint NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table bookstore.category: ~15 rows (approximately)
INSERT INTO `category` (`Id`, `Name`, `IsDeleted`, `CreatedAt`, `UpdatedAt`) VALUES
	(1, 'Tâm lí kĩ năng sống', 0, '2023-12-10 12:46:09', '2023-12-10 12:46:11'),
	(2, 'Kinh tế', 0, '2023-12-10 12:46:09', '2023-12-10 12:46:11'),
	(3, 'Tiểu thuyết', 0, '2023-12-10 12:46:09', '2023-12-14 17:38:41'),
	(4, 'FOREIGN BOOKS', 0, '2023-12-10 12:46:09', '2023-12-10 12:46:11'),
	(5, 'Nuôi dạy con', 0, '2023-12-10 12:46:09', '2023-12-10 12:46:11'),
	(6, 'Sách thiếu nhi', 0, '2023-12-10 12:46:09', '2023-12-10 12:46:11'),
	(7, 'Sách tâm lý', 0, '2023-12-10 12:46:09', '2023-12-10 12:46:11'),
	(8, 'Sách chính trị ', 0, '2023-12-10 12:46:09', '2023-12-10 12:46:11'),
	(9, 'Ngôn tình', 0, '2023-12-10 12:46:09', '2023-12-10 12:46:11'),
	(10, 'Sách Tham khảo', 0, '2023-12-10 12:46:09', '2023-12-10 12:46:11'),
	(12, 'Tâm lí', 0, '2023-12-14 04:06:05', '2023-12-14 04:06:05'),
	(13, 'Tâm lí', 0, '2023-12-14 04:08:00', '2023-12-14 04:08:00'),
	(14, 'Tâm lí', 0, '2023-12-14 10:08:35', '2023-12-14 10:08:35'),
	(15, 'Tâm lí', 0, '2023-12-14 10:19:06', '2023-12-14 10:19:06'),
	(16, 'Tâm lí kĩ năng sống', 0, '2023-12-14 13:30:17', '2023-12-14 13:30:17');

-- Dumping structure for table bookstore.customer
CREATE TABLE IF NOT EXISTS `customer` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext,
  `Phone` longtext,
  `BirthDay` datetime NOT NULL,
  `Address` longtext,
  `Gender` longtext,
  `IsDeleted` tinyint NOT NULL DEFAULT '0',
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table bookstore.customer: ~23 rows (approximately)
INSERT INTO `customer` (`Id`, `Name`, `Phone`, `BirthDay`, `Address`, `Gender`, `IsDeleted`, `CreatedAt`, `UpdatedAt`) VALUES
	(0, 'Khách Vãng Lai', '0398765421', '2023-12-11 16:19:25', 'Tân Bình', '0', 1, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(1, 'Nguyễn Văn Anh', '0398765421', '2023-12-11 16:19:25', 'Tân Bình', '0', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(2, 'Chu Thanh Bình', '0398765421', '2023-12-11 16:19:25', 'Quận 1', '0', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(3, 'Trần  Thị Chi', '0398765421', '2023-12-11 16:19:25', 'Quận 2', '1', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(4, 'Phạm Minh Đức', '0398765421', '2023-12-11 16:19:25', 'Quận 3', '0', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(5, 'Võ Đức Giang', '0398765421', '2023-12-11 16:19:25', 'Quận 4', '0', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(6, 'Lê Thị Hồng', '0398765421', '2023-12-11 16:19:25', 'Quận 5', '1', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(7, 'Đinh  Tuấn Khôi', '0398765421', '2023-12-11 16:19:25', 'Quận 6', '0', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(8, 'Lưu  Anh Linh', '0398765421', '2023-12-11 16:19:25', 'Quận 7', '0', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(9, 'Huỳnh Thị Ngọc Linh', '0398765421', '2023-12-11 16:19:25', 'Quận 8', '1', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(10, 'Bùi Thanh Minh', '0398765421', '2023-12-11 16:19:25', 'Quận 9', '0', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(11, 'Bùi Thanh Mai', '0398765421', '2023-12-11 16:19:25', 'Quận 10', '1', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(12, 'Trần Hà My', '0398765421', '2023-12-11 16:19:25', 'Quận 11', '1', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(13, 'Đỗ Hoài Nam', '0398765421', '2023-12-11 16:19:25', 'Quận 12', '0', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(14, 'Trần Thị Thu Phương', '0398765421', '2023-12-11 16:19:25', 'Hóc Môn', '1', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(15, 'Đinh  Tuấn Phúc', '0398765421', '2023-12-11 16:19:25', 'Củ Chi', '0', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(16, 'Ngô Quốc Sơn', '0398765421', '2023-12-11 16:19:25', 'Quận 1', '0', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(17, 'Nguyễn Thị Thu Trang', '0398765421', '2023-12-11 16:19:25', 'Quận 2', '1', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(18, 'Đỗ  Trang Uyên', '0398765421', '2023-12-11 16:19:25', 'Quận 3', '1', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(19, 'Lưu  Anh Việt', '0398765421', '2023-12-11 16:19:25', 'Quận 4', '0', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(20, 'Bùi Thanh Vy', '0398765421', '2023-12-11 16:19:25', 'Quận 5', '1', 0, '2023-12-11 16:19:48', '2023-12-11 16:19:49'),
	(25, '', '', '2023-12-14 16:32:05', '', '1', 0, '2023-12-14 16:32:06', '2023-12-14 16:32:06'),
	(26, 'áds', '0987654321', '2023-12-04 16:45:57', 'ádsa', '1', 0, '2023-12-14 16:46:34', '2023-12-14 16:46:34');

-- Dumping structure for table bookstore.discount
CREATE TABLE IF NOT EXISTS `discount` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext,
  `Value` float NOT NULL,
  `EndDate` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `Quantity` int NOT NULL DEFAULT '0',
  `StartDate` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `CreatedAt` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `IsDeleted` tinyint NOT NULL DEFAULT '0',
  `UpdatedAt` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table bookstore.discount: ~21 rows (approximately)
INSERT INTO `discount` (`Id`, `Name`, `Value`, `EndDate`, `Quantity`, `StartDate`, `CreatedAt`, `IsDeleted`, `UpdatedAt`) VALUES
	(0, 'KHÔNG GIẢM GIÁ', 0, '2023-12-15 21:18:00', 0, '2023-12-14 21:18:00', '2023-12-13 21:20:38', 0, '2023-12-14 17:39:18'),
	(1, 'GIAM_5', 5, '2023-12-12 21:18:00', 100, '2023-12-24 21:18:00', '2023-12-13 21:20:38', 0, '2023-12-14 17:39:18'),
	(2, 'GIAM_10', 10, '2023-12-11 16:19:25', 20, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38'),
	(3, 'GIAM_15', 15, '2023-12-11 16:19:25', 20, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38'),
	(4, 'GIAM_18', 18, '2023-12-13 21:20:38', 20, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38'),
	(5, 'GIAM_20', 20, '2023-12-13 21:20:38', 20, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38'),
	(6, 'GIAM_25', 25, '2023-12-11 16:19:25', 20, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38'),
	(7, 'GIAM_30', 30, '2023-12-13 21:20:38', 20, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38'),
	(8, 'GIAM_35', 35, '2023-12-11 16:19:25', 20, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38'),
	(9, 'GIAM_40', 40, '2023-12-13 21:20:38', 20, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38'),
	(10, 'GIAM_45\r\n', 45, '2023-12-13 21:20:38', 20, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38'),
	(11, 'GIAM_50', 50, '2023-12-13 21:20:38', 10, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38'),
	(12, 'GIAM_55', 55, '2023-12-13 21:20:38', 10, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38'),
	(13, 'GIAM_60', 60, '2023-12-13 21:20:38', 10, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38'),
	(14, 'GIAM_65', 65, '2023-12-13 21:20:38', 10, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38'),
	(15, 'GIAM_68', 68, '2023-12-13 21:20:38', 10, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38'),
	(16, 'GIAM_70', 70, '2023-12-13 21:20:38', 10, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38'),
	(17, 'GIAM_75', 75, '2023-12-13 21:20:38', 5, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38'),
	(18, 'GIAM_80', 80, '2023-12-13 21:20:38', 5, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38'),
	(19, 'GIAM_85', 85, '2023-12-13 21:20:38', 5, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38'),
	(20, 'GIAM_90', 90, '2023-12-13 21:20:38', 5, '2023-12-13 21:20:38', '2023-12-13 21:20:38', 0, '2023-12-13 21:20:38');

-- Dumping structure for table bookstore.importdetail
CREATE TABLE IF NOT EXISTS `importdetail` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ImportId` int DEFAULT NULL,
  `BookDetailId` int DEFAULT NULL,
  `Price` double NOT NULL,
  `BuyQuantity` int NOT NULL,
  `IsDeleted` tinyint NOT NULL DEFAULT '0',
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ImportDetail_BookDetailId` (`BookDetailId`),
  KEY `IX_ImportDetail_ImportId` (`ImportId`),
  CONSTRAINT `FK_ImportDetail_BookDetail_BookDetailId` FOREIGN KEY (`BookDetailId`) REFERENCES `bookdetail` (`Id`),
  CONSTRAINT `FK_ImportDetail_Import_ImportId` FOREIGN KEY (`ImportId`) REFERENCES `imports` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table bookstore.importdetail: ~3 rows (approximately)
INSERT INTO `importdetail` (`Id`, `ImportId`, `BookDetailId`, `Price`, `BuyQuantity`, `IsDeleted`, `CreatedAt`, `UpdatedAt`) VALUES
	(1, 1, 1, 90000, 100, 0, '2023-12-14 23:25:55', '2023-12-14 23:25:55'),
	(2, 1, 2, 90000, 100, 0, '2023-12-14 23:25:55', '2023-12-14 23:25:55'),
	(3, 7, 3, 120000, 3, 0, '2023-12-15 01:24:55', '2023-12-15 01:24:55');

-- Dumping structure for table bookstore.imports
CREATE TABLE IF NOT EXISTS `imports` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ImportDate` datetime NOT NULL,
  `Status` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `AccountId` int DEFAULT NULL,
  `IsDeleted` tinyint NOT NULL DEFAULT '0',
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Import_AccountId` (`AccountId`),
  CONSTRAINT `FK_Import_Accounts_AccountId` FOREIGN KEY (`AccountId`) REFERENCES `accounts` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table bookstore.imports: ~2 rows (approximately)
INSERT INTO `imports` (`Id`, `ImportDate`, `Status`, `AccountId`, `IsDeleted`, `CreatedAt`, `UpdatedAt`) VALUES
	(1, '2023-12-14 23:22:25', 'Thành công', 1, 0, '2023-12-14 23:22:39', '2023-12-14 23:22:40'),
	(7, '2023-12-15 01:24:49', 'Đang thanh toán', 1, 0, '2023-12-15 01:24:49', '2023-12-15 01:24:49');

-- Dumping structure for table bookstore.orderdetail
CREATE TABLE IF NOT EXISTS `orderdetail` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `OrderId` int DEFAULT NULL,
  `BookDetailId` int DEFAULT NULL,
  `Price` double NOT NULL,
  `BuyQuantity` int NOT NULL,
  `IsDeleted` tinyint NOT NULL DEFAULT '0',
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_OrderDetail_BookDetailId` (`BookDetailId`),
  KEY `IX_OrderDetail_OrderId` (`OrderId`),
  CONSTRAINT `FK_orderdetail_bookdetail` FOREIGN KEY (`BookDetailId`) REFERENCES `bookdetail` (`Id`),
  CONSTRAINT `FK_OrderDetail_Order_OrderId` FOREIGN KEY (`OrderId`) REFERENCES `orders` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table bookstore.orderdetail: ~8 rows (approximately)
INSERT INTO `orderdetail` (`Id`, `OrderId`, `BookDetailId`, `Price`, `BuyQuantity`, `IsDeleted`, `CreatedAt`, `UpdatedAt`) VALUES
	(1, 1, 1, 10000, 1, 0, '2023-12-14 02:32:39', '2023-12-14 02:32:39'),
	(2, 1, 2, 10000, 1, 0, '2023-12-14 02:32:39', '2023-12-14 02:32:39'),
	(3, 2, 11, 10000, 1, 0, '2023-12-14 02:32:39', '2023-12-14 02:32:39'),
	(6, 3, 1, 248000, 1, 0, '2023-12-14 13:04:13', '2023-12-14 13:04:13'),
	(7, 4, 8, 95000, 1, 0, '2023-12-14 13:12:25', '2023-12-14 13:12:25'),
	(8, 5, 1, 248000, 1, 0, '2023-12-14 13:39:38', '2023-12-14 13:39:38'),
	(9, 5, 2, 239000, 1, 0, '2023-12-14 13:39:38', '2023-12-14 13:39:38'),
	(10, 9, 2, 239000, 1, 0, '2023-12-14 15:22:08', '2023-12-14 15:22:08');

-- Dumping structure for table bookstore.orders
CREATE TABLE IF NOT EXISTS `orders` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `OrderDate` datetime NOT NULL,
  `CustomerId` int DEFAULT NULL,
  `AccountId` int DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `IsDeleted` tinyint NOT NULL DEFAULT '0',
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Order_AccountId` (`AccountId`),
  KEY `IX_Order_CustomerId` (`CustomerId`),
  CONSTRAINT `FK_Order_Accounts_AccountId` FOREIGN KEY (`AccountId`) REFERENCES `accounts` (`Id`),
  CONSTRAINT `FK_Order_Customer_CustomerId` FOREIGN KEY (`CustomerId`) REFERENCES `customer` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table bookstore.orders: ~7 rows (approximately)
INSERT INTO `orders` (`Id`, `OrderDate`, `CustomerId`, `AccountId`, `Status`, `IsDeleted`, `CreatedAt`, `UpdatedAt`) VALUES
	(1, '2023-12-14 01:29:50', 1, 1, 'Thành Công', 0, '2023-12-14 01:30:00', '2023-12-14 01:30:01'),
	(2, '2023-12-14 01:29:50', 18, 1, 'Thành Công', 0, '2023-12-14 01:30:00', '2023-12-14 01:30:01'),
	(3, '0001-01-01 00:00:00', 1, 1, 'Thành Công', 0, '2023-12-14 13:04:13', '2023-12-14 13:04:13'),
	(4, '2023-12-14 13:12:25', 1, 1, 'Thành Công', 0, '2023-12-14 13:12:25', '2023-12-14 13:12:25'),
	(5, '2023-12-14 13:39:38', 1, 1, 'Thành Công', 0, '2023-12-14 13:39:38', '2023-12-14 13:39:38'),
	(9, '2023-12-14 15:21:46', 2, 1, 'Thành Công', 0, '2023-12-14 15:21:46', '2023-12-14 15:21:46'),
	(10, '2023-12-14 15:22:54', 0, 8, 'Thành Công', 0, '2023-12-14 15:22:49', '2023-12-14 15:22:49');

-- Dumping structure for table bookstore.publisher
CREATE TABLE IF NOT EXISTS `publisher` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext,
  `IsDeleted` tinyint NOT NULL DEFAULT '0',
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table bookstore.publisher: ~16 rows (approximately)
INSERT INTO `publisher` (`Id`, `Name`, `IsDeleted`, `CreatedAt`, `UpdatedAt`) VALUES
	(1, 'Tổng Hợp TPHCM', 0, '2023-12-11 16:11:20', '2023-12-11 16:11:21'),
	(2, 'Lao Động', 0, '2023-12-11 16:11:20', '2023-12-11 16:11:21'),
	(3, 'Dân Trí', 0, '2023-12-11 16:11:20', '2023-12-11 16:11:21'),
	(4, 'Văn Học', 0, '2023-12-11 16:11:20', '2023-12-11 16:11:21'),
	(5, 'Trẻ', 0, '2023-12-11 16:11:20', '2023-12-11 16:11:21'),
	(6, 'Thanh Niên', 0, '2023-12-11 16:11:20', '2023-12-11 16:11:21'),
	(7, 'Cambridge University', 0, '2023-12-11 16:11:20', '2023-12-11 16:11:21'),
	(8, 'Oxford', 0, '2023-12-11 16:11:20', '2023-12-11 16:11:21'),
	(9, 'Vintage Publishing', 0, '2023-12-11 16:11:20', '2023-12-11 16:11:21'),
	(10, 'Thế Giới', 0, '2023-12-11 16:11:20', '2023-12-11 16:11:21'),
	(11, 'Kim Đồng', 0, '2023-12-11 16:11:20', '2023-12-11 16:11:21'),
	(12, 'Hội Nhà Văn', 0, '2023-12-11 16:11:20', '2023-12-11 16:11:21'),
	(13, 'Hà Nội', 0, '2023-12-11 16:11:20', '2023-12-11 16:11:21'),
	(14, 'Hồng Đức', 0, '2023-12-11 16:11:20', '2023-12-11 16:11:21'),
	(15, 'Phụ Nữ', 0, '2023-12-11 16:11:20', '2023-12-11 16:11:21'),
	(16, 'Đại Học Quốc Gia Hà Nội', 0, '2023-12-11 16:11:20', '2023-12-11 16:11:21');

-- Dumping structure for table bookstore.role
CREATE TABLE IF NOT EXISTS `role` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext,
  `IsDeleted` tinyint NOT NULL DEFAULT '0',
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table bookstore.role: ~4 rows (approximately)
INSERT INTO `role` (`Id`, `Name`, `IsDeleted`, `CreatedAt`, `UpdatedAt`) VALUES
	(1, 'admin', 0, '2023-12-11 16:00:25', '0001-01-01 00:00:00'),
	(2, 'manage', 0, '2023-12-11 16:00:25', '2023-12-11 16:00:25'),
	(3, 'seller', 0, '2023-12-11 16:00:25', '2023-12-11 16:00:25'),
	(4, 'accounter', 0, '2023-12-11 16:00:25', '2023-12-11 16:00:25');

-- Dumping structure for table bookstore.supplier
CREATE TABLE IF NOT EXISTS `supplier` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext,
  `Phone` longtext,
  `Address` longtext,
  `IsDeleted` tinyint NOT NULL DEFAULT '0',
  `CreatedAt` datetime NOT NULL,
  `UpdatedAt` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table bookstore.supplier: ~21 rows (approximately)
INSERT INTO `supplier` (`Id`, `Name`, `Phone`, `Address`, `IsDeleted`, `CreatedAt`, `UpdatedAt`) VALUES
	(1, 'FIRST NEWS', '0897654321', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(2, '1980 Books', '0897654322', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(3, 'Bách Việt', '0897654323', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(4, 'Cty CP MTV Hà Nội', '0897654324', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(5, 'NXB Trẻ', '0897654325', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(6, 'Đinh Tị', '0897654326', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(7, 'Cambridge University Press', '0897654327', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(8, 'Oxford University Press', '0897654328', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(9, 'HarperCollins Publishers', '0897654329', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(10, 'Thái Hà', '0897654330', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(11, 'Công ty TNHH Sách Hà Giang', '0897654331', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(12, 'Nhà Xuất Bản Kim Đồng', '0897654332', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(13, 'AZ Việt Nam', '0897654333\r\n', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(14, 'Saigon Books', '0897654334', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(15, 'Công ty TNHH Xuất Bản Và Truyền Thông Bestbooks Việt Nam', '0897654335', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(16, 'Phanbook', '0897654336', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(17, 'Nhã Nam', '0897654337', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(18, 'Phụ Nữ', '0897654338\r\n', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(19, 'Minh Long', '0897654339', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(20, 'NXB Hồng Đức', '0897654340', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48'),
	(21, 'Alpha Books', '0897654341', '273 Đ. An Dương Vương, Phường 3, Quận 5, Thành phố Hồ Chí Minh', 0, '2023-12-11 16:01:47', '2023-12-11 16:01:48');

-- Dumping structure for table bookstore.__efmigrationshistory
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci AVG_ROW_LENGTH=2730;

-- Dumping data for table bookstore.__efmigrationshistory: ~6 rows (approximately)
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20231005090705_init', '6.0.20'),
	('20231110033841_init4', '6.0.20'),
	('20231110044305_init5', '6.0.20'),
	('20231117045915_init10', '6.0.20'),
	('20231117050519_init11', '6.0.20'),
	('20231117051654_init12', '6.0.20');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
