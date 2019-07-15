INSERT INTO .HM.Medium_User
(
    --UserId - column value is auto-generated
    UserName,
	UserFirstName,
	UserMiddleName,
	UserLastName,
    EmailAddress,
    Password,
    MobileNumber,
    TwitterAccount,
    FaceBookAccount,
    WechatAccount,
    UserAvatar,
    UserSelfDescription,
    CreationDateTime,
    UpdateDateTime
)
VALUES
(
    -- UserId - int
    'RebeccaF', -- UserName - varchar
	'Rebecca',
	NULL,
	'Fishbein'
    N'RebeccaFishbein@hm.com', -- EmailAddress - nvarchar
    N'RebaccaF', -- Password - nvarchar
    '001-917-868-2100', -- MobileNumber - varchar
    N'', -- TwitterAccount - nvarchar
    N'', -- FaceBookAccount - nvarchar
    N'', -- WechatAccount - nvarchar
    N'https://cdn-images-1.medium.com/fit/c/100/100/1*1EaqeHNxVoJK8Ul4EMlfWA.jpeg', -- UserAvatar - nvarchar
    N'A writer from Brooklyn. Find my Twitter at @bfishbfish', -- UserSelfDescription - nvarchar
    '2019-02-07 19:22:18', -- CreationDateTime - datetime
    '2019-02-07 19:22:18' -- UpdateDateTime - datetime
)

INSERT INTO .HM.Medium_Article
(
	ArticleStatus ,
	ArticleAuthorId,
	ArticelCollectionId,
	ArticleTag,
	ArticleFeaturedImage,
	ArticleDisplayTitle,
	ArticleDisplaySubtitle,
	CustomizedArticleLink
)
VALUES
(
    'active', -- ArticleStatus - varchar
	1, --ArticleAuthorId
	1, --ArticleCollectionId
    'Employment', -- Tags - varchar
    N'https://cdn-images-1.medium.com/max/1600/0*SV8mG0zMYdREioMg', -- ArticleFeaturedImage - nvarchar
    N'How to Tell an Employee Their Work Isn\''t Good Enough', -- ArticleDisplayTitle - nvarchar
    N'A script for outlining your expectations kindly, clearly, and firmly', -- ArticleDisplaySubtitle - nvarchar
    N'' -- CustomizedArticleLink - nvarchar
)

INSERT INTO.HM.Medium_Article_Content
(
    --ArticleContentId - column value is auto-generated
    ArticleId,
    ParagraphNumber,
    ParagraphEmbedContent
)
VALUES
(
    -- ArticleContentId - int
    1, -- ArticleId - int
    1, -- ParagraphNumber - int
    N'<img class="article-content-img" src="https://cdn-images-1.medium.com/max/1600/0*SV8mG0zMYdREioMg">' -- ParagraphEmbedContent - nvarchar
),
(
    -- ArticleContentId - int
    1, -- ArticleId - int
    2, -- ParagraphNumber - int
    N'<p class="graf graf--p graf--hasDropCapModel graf--hasDropCap graf--hasDropCapImage graf-after--figure"><span class="dropCap"><span class="aspectRatioPlaceholder"><img class="paragraphCapImage" src="https://cdn-images-1.medium.com/max/800/1*Rc8grmA2r8PeKj1Ts3m53w.png"></span></span> an employee is missing targets, blowing deadlines, or handing in shoddy work, it can be tempting to push off any conversation about it and hope that things get better on their own. But you’re not just doing yourself and your company a disservice by staying quiet. An employee who’s falling short deserves to know it so that they have the opportunity to self-correct before things get too dire. And having to fire someone is even more uncomfortable than stepping in earlier.</p>' -- ParagraphEmbedContent - nvarchar
),
(
    -- ArticleContentId - int
    1, -- ArticleId - int
    3, -- ParagraphNumber - int
    N'<p name="7220" id="7220" class="graf graf--p graf-after--p">Delivering the news effectively, though, is a delicate art.“It’s important to remember that this person has emotions and feelings attached to the information they’re receiving,” says industrial-organizational psychologist <a href="http://www.amycooperhakim.com/" data-href="http://www.amycooperhakim.com/" class="markup--anchor markup--p-anchor" rel="noopener" target="_blank">Amy Cooper Hakim</a>, author of <em class="markup--em markup--p-em">Working with Difficult People </em>and founder of the Cooper Strategic Group.</p>' -- ParagraphEmbedContent - nvarchar
)

SELECT * FROM .HM.Medium_User mu

SELECT ma.ArticleId, 
	ma.ArticleStatus, 
	ma.ArticleAuthorId, 
	ma.ArticleTag,
	ma.ArticleDisplayTitle,
	ma.ArticleDisplaySubtitle,
	ma.ArticleFeaturedImage AS ArticleFeatureImage
FROM .HM.Medium_Article ma


SELECT * FROM .HM.Medium_Article_Content mac

SELECT * FROM 
 (SELECT ROW_NUMBER() OVER (ORDER BY ArticleId DESC) AS ArticleRowNumber, *
  FROM .HM.Medium_Article ) Articles
WHERE Articles.ArticleRowNumber BETWEEN 6 AND 15

SELECT * FROM .HM.Medium_Article ORDER BY ArticleId DESC OFFSET 5 ROWS FETCH NEXT 15 ROWS ONLY

