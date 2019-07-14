--CREATE SCHEMA HM

/*
DROP TABLE .HM.Medium_User
DROP TABLE .HM.Medium_User_Keyboards
DROP TABLE .HM.Medium_Collection
DROP TABLE .HM.Medium_Article
DROP TABLE .HM.Medium_Article_Content
DROP TABLE .HM.Medium_Article_Image_Video_Library
DROP TABLE .HM.FollowActivity
DROP TABLE .HM.ReadActivity
DROP TABLE .HM.BookMarkActivity
DROP TABLE .HM.ResponseContent
DROP TABLE .HM.ResponseActivity
DROP TABLE .HM.ClapActivity
*/

CREATE TABLE .HM.Medium_User(
	UserId int IDENTITY PRIMARY KEY,
	UserName varchar(50),
	UserFirstName varchar(100),
	UserMiddleName varchar(100),
	UserLastName varchar(100),
	EmailAddress nvarchar(100),
	Password nvarchar(100),
	MobileNumber varchar(25),
	TwitterAccount nvarchar(25),
	FaceBookAccount nvarchar(25),
	WechatAccount nvarchar(25),
	UserAvatar nvarchar(Max),
	UserSelfDescription nvarchar(Max),
	CreationDateTime datetime,
	UpdateDateTime datetime
)

CREATE TABLE .HM.Medium_Collection(
	CollectionId int PRIMARY KEY,
	CollectionName varchar(25),
	CollectionAvatar nvarchar(Max),
	CollectionAbstract nvarchar(Max),
	CollectionDescription nvarchar(Max),
	CreationDateTime datetime,
	UpdateDateTime datetime
)

CREATE TABLE .HM.Medium_Article(
	ArticleId int IDENTITY PRIMARY KEY,
	--ArticleVersion int,
	ArticleStatus varchar(25),
	ArticleAuthorId int FOREIGN KEY REFERENCES HM.Medium_User(UserId),
	ArticleCollectionId int,-- FOREIGN KEY REFERENCES HM.Medium_Collection(CollectionId),
	ArticleTag varchar(25),
	ArticleFeatureImage nvarchar(Max),
	ArticleDisplayTitle nvarchar(Max),
	ArticleDisplaySubtitle nvarchar(Max),
	CustomizedArticleLink nvarchar(Max),
	ArticleReadTime int,
	ArticleCreationTime datetime,
	ArticleUpdateTime datetime
)

CREATE TABLE .HM.Medium_Article_Content(
	ArticleContentId int IDENTITY PRIMARY KEY,
	ArticleId int FOREIGN KEY REFERENCES HM.Medium_Article(ArticleId), 
	ParagraphNumber int,
	ParagraphEmbedContent nvarchar(Max)
)

CREATE TABLE .HM.Medium_Article_Image_Video_Library(
	ArticalImageVideoId int IDENTITY PRIMARY KEY,
	ArticalId int FOREIGN KEY REFERENCES HM.Medium_Article(ArticleId),
	ArticalImageVideoType int,
	ArticalImageVideoLink nvarchar(Max)
)

CREATE TABLE .HM.FollowActivity(
	FollowActivityId int IDENTITY PRIMARY KEY,
	Direction varchar(10) NOT NULL CHECK (Direction in('Follow', 'UnFollow')),
	UserId int FOREIGN KEY REFERENCES HM.Medium_User(UserId),
	PassiveUserId int FOREIGN KEY REFERENCES HM.Medium_User(UserId),
	FollowTimeStamp timestamp
)

CREATE TABLE .HM.ReadActivity(
	ReadActivityId int IDENTITY PRIMARY KEY,
	UserId int FOREIGN KEY REFERENCES HM.Medium_User(UserId),
	ArticleId int FOREIGN KEY REFERENCES HM.Medium_Article(ArticleId),
	StartTime datetime,
	EndTime datetime
)

CREATE TABLE .HM.BookMarkActivity(
	BookMarkActivityId int IDENTITY PRIMARY KEY,
	Direction varchar(15) NOT NULL CHECK(Direction IN('BookMark', 'UnBookMark')),
	UserId int FOREIGN KEY REFERENCES HM.Medium_User(UserId),
	ArticleId int FOREIGN KEY REFERENCES HM.Medium_Article(ArticleId),
	BookMarkTimeStamp timestamp
)

CREATE TABLE .HM.ResponseContent(
	ResponseContentId int IDENTITY PRIMARY KEY,
	ResponseStatus varchar(25),
	ResponseContent nvarchar(25),
	CreateDateTime datetime,
	UpdateDateTime datetime
)

CREATE TABLE .HM.ResponseActivity(
	ResponseActivityId int IDENTITY PRIMARY KEY,
	UserId int FOREIGN KEY REFERENCES HM.Medium_User(UserId),
	ArticleId int FOREIGN KEY REFERENCES HM.Medium_Article(ArticleId),
	ParentResponseId int FOREIGN KEY REFERENCES HM.ResponseContent(ResponseContentId),
	ResponseId int FOREIGN KEY REFERENCES HM.ResponseContent(ResponseContentId),
	ResponseTimeStamp timestamp
)

CREATE TABLE .HM.ClapActivity(
	ClapActivityId int IDENTITY PRIMARY KEY,
	Direction varchar(10) NOT NULL CHECK(Direction IN('Clap', 'UnClap')),
	UserId int FOREIGN KEY REFERENCES HM.Medium_User(UserId),
	ArticleId int FOREIGN KEY REFERENCES HM.Medium_Article(ArticleId),
	ResponseId int FOREIGN KEY REFERENCES HM.ResponseContent(ResponseContentId),
	ClapTimeStamp timestamp
)