CREATE PROCEDURE dbo.GetArtistDetails
	@artistId int = -1
	
AS
BEGIN

	SELECT Album.title AS albumTitle, Album.imageURL AS aLbumImage, Album.year AS albumYear,
       Song.title AS songTitle, Song.bpm AS songBpm, Song.timeSignature AS songTimeSignature,
	   Artist.title AS artistTitle, Artist.heroURL AS artistHeroImg, Artist.imageURL AS artistImg, Artist.biography AS artistBiography
	FROM Artist
	LEFT JOIN Album ON Album.artistID = ARTIST.artistID
	LEFT JOIN Song ON Song.albumID = Album.albumID
	WHERE Artist.artistID = @artistId
	ORDER BY Song.title, Album.title

	
END