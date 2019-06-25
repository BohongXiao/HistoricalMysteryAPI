CREATE TABLE .dbo.Medium_User(
	UserId uniqueidentifier,
	UserName varchar(50),
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

CREATE TABLE .dbo.Medium_User_Keyboards(
	KeyBoardSetupId uniqueidentifier,
	UserId int,
	KeyCombination nvarchar(100),
	Functionality nvarchar(100)
)


CREATE TABLE .dbo.Medium_Article(
	ArticleId Int,
	ArticleVersion int,
	ArticleStatus varchar(25),
	Tags varchar(25),
	ArticleFeaturedImage nvarchar(Max),
	ArticleDisplayTitle nvarchar(Max),
	ArticleDisplaySubtitle nvarchar(Max),
	CustomizedArticleLink nvarchar(Max)
)

CREATE TABLE .dbo.Medium_Article_Content(
	ArticleContentId uniqueidentifier,
	ArticleId int, 
	ParagraphNumber int,
	ParagraphEmbedContent nvarchar(Max)
)

CREATE TABLE .dbo.Medium_Article_Image_Video_Library(
	ArticalImageVideoId uniqueidentifier,
	ArticalId int,
	ArticalImageVideoType int,
	ArticalImageVideoLink nvarchar(Max)
)

CREATE TABLE .dbo.FollowActivity(
	FollowActivityId uniqueidentifier,
	Direction int,
	UserId int,
	PassiveUserId int,
	TimeStamp timestamp
)

CREATE TABLE .dbo.ReadActivity(
	ReadActivityId uniqueidentifier,
	UserId int,
	ArticleId int,
	StartTime datetime,
	EndTime datetime
)

CREATE TABLE .dbo.ClapActivity(
	ClapActivityId uniqueidentifier,
	Directioin int,
	UserId int,
	ArticleId int,
	ResponseId int,
	TimeStamp timestamp
)

CREATE TABLE .dbo.BookMarkActivity(
	BookMarkActivityId uniqueidentifier,
	DirectionId int,
	UserId int,
	ArticleId int,
	TimeStamp timestamp
)

CREATE TABLE .dbo.ResponseActivity(
	ResponseActivityId uniqueidentifier,
	UserId int,
	ArticleId int,
	ParentResponseId int,
	ResponseId int,
	TimeStamp timestamp
)

CREATE TABLE .dbo.ResponseId(
	ResponseContentId uniqueidentifier,
	ResponseStatus varchar(25),
	ResponseContent nvarchar(25),
	CreateDateTime datetime,
	UpdateDateTime datetime
)