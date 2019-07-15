--DECLARE @userId int
--DECLARE @articleFeatureImage nvarchar(max) N'https://miro.medium.com/max/1600/1*uEx7CWBE3cf-IzKzNcZscQ.jpeg'
--DECLARE @articleTitle nvarchar(max)
--DECLARE @articleSubTitle nvarchar(max)
--DECLARE @insertedArticleId int

--DROP TYPE HM.ArticleContent
--DROP PROCEDURE .HM.sp_HM_RW_SaveNewArticle

CREATE TYPE HM.ArticleContent AS TABLE ( 
	ParagraphNumber int,
	ParagraphEmbedContent nvarchar(max)
)  
GO

CREATE OR ALTER PROCEDURE .HM.sp_HM_RW_SaveNewArticle(
	@userId int,
	@articleFeatureImage nvarchar(max),
	@articleTitle nvarchar(max),
	@articleSubTitle nvarchar(max),
	@articleContent HM.ArticleContent READONLY,
	@articleId int OUTPUT
)
AS
BEGIN
	BEGIN TRANSACTION InsertArticle

	DECLARE @IdentityOutput Table ( ID int )

	INSERT INTO .HM.Medium_Article
	(
		--ArticleId - column value is auto-generated
		ArticleStatus,
		ArticleAuthorId,
		ArticleFeatureImage,
		ArticleDisplayTitle,
		ArticleDisplaySubtitle
	)
	output inserted.ArticleId into @IdentityOutput
	VALUES
	(
		-- ArticleId - int
		'Active', -- ArticleStatus - varchar
		@userId, -- ArticleAuthorId - int
		@articleFeatureImage, -- ArticleFeaturedImage - nvarchar
		@articleTitle, -- ArticleDisplayTitle - nvarchar
		@articleSubTitle -- ArticleDisplaySubtitle - nvarchar
	)

	INSERT INTO .HM.Medium_Article_Content
	(
	    --ArticleContentId - column value is auto-generated
	    ArticleId,
	    ParagraphNumber,
	    ParagraphEmbedContent
	)
	SELECT (SELECT TOP 1 ID FROM @IdentityOutput io),
		ac.ParagraphNumber,
		ac.ParagraphEmbedContent
	FROM @articleContent ac

	SELECT @articleId = (SELECT TOP 1 ID FROM @IdentityOutput io)

	COMMIT TRANSACTION InsertArticle
END 