CREATE PROCEDURE dbo.GetArtistDetails
	@artistId int = -1
	
AS
BEGIN

-- Artist's Information
	SELECT Artist.title AS artistTitle, Artist.heroURL AS artistHeroImg, Artist.imageURL AS artistImg, Artist.biography AS artistBiography
	FROM Artist
	WHERE artistID = @artistId

-- Artist's Albums 

	SELECT Album.title AS albumTitle, Album.imageURL AS albumImg, Album.[year] AS albumYear,  Artist.title AS artistTitle
	FROM Album JOIN Artist ON Album.artistID = Artist.artistID
	WHERE Album.artistID = @artistId

-- Artist's Songs
	SELECT Album.title AS albumTitle, Album.imageURL AS albumImg, Album.[year] AS albumYear,
       Song.title AS songTitle, Song.bpm AS songBpm, Song.timeSignature AS songTimeSignature
	FROM Album JOIN Song ON  Song.albumID = Album.albumID
	WHERE Album.artistID = @artistId
	ORDER BY Song.title, Album.title


	
	
END