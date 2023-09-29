// Copyright Eternal Developments, LLC. All Rights Reserved.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

// The attribute decorations (Table and Key) are not required but added for clarity.
// The members marked with [Key] are the primary keys for their table.
// The foreign keys are automatically generated from [Classname]Id - e.g. ArtistId

// Some docs to start ou - https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/workflows/new-database

namespace MusicDatabase
{
	[Table( "Artists" )]
	public class Artist
	{
		[Key] public int ArtistId { get; set; }
		public string ArtistName { get; set; } = string.Empty;

		public virtual ICollection<Track> TracksByArtist { get; } = new HashSet<Track>();

		public Artist()
		{
		}

		public Artist( string artistName ) => ArtistName = artistName;

		public static int Add( MusicLibrary db, string artistName )
		{
			Artist? artist = db.Artists.FirstOrDefault<Artist>( s => s.ArtistName == artistName );
			if( artist == null )
			{
				db.Artists.Add( artist = new Artist( artistName ) );
			}

			return artist.ArtistId;
		}
	}

	[Table( "Composers" )]
	public class Composer
	{
		[Key] public int ComposerId { get; set; }
		public string ComposerName { get; set; } = string.Empty;

		public virtual ICollection<Track> TracksByComposer { get; } = new HashSet<Track>();

		public Composer()
		{
		}

		public Composer( string composerName ) => ComposerName = composerName;

		public static int Add( MusicLibrary db, string composerName )
		{
			Composer? composer = db.Composers.FirstOrDefault<Composer>( s => s.ComposerName == composerName );
			if( composer == null )
			{
				db.Composers.Add( composer = new Composer( composerName ) );
			}

			return composer.ComposerId;
		}
	}

	[Table( "Genres" )]
	public class Genre
	{
		[Key] public int GenreId { get; set; }
		public string GenreName { get; set; } = string.Empty;

		public virtual ICollection<Track> TracksByGenre { get; } = new HashSet<Track>();

		public Genre()
		{
		}

		public Genre( string genreName ) => GenreName = genreName;

		public static int Add( MusicLibrary db, string genreName )
		{
			Genre? genre = db.Genres.FirstOrDefault<Genre>( s => s.GenreName == genreName );
			if( genre == null )
			{
				db.Genres.Add( genre = new Genre( genreName ) );
			}

			return genre.GenreId;
		}
	}

	[Table( "Albums" )]
	public class Album
	{
		public int AlbumId { get; set; }
		public string AlbumName { get; set; } = string.Empty;

		public virtual ICollection<Track> TracksByAlbum { get; } = new HashSet<Track>();

		public Album()
		{
		}

		public Album( string albumName ) => AlbumName = albumName;

		public static int Add( MusicLibrary db, string albumName )
		{
			Album? album = db.Albums.FirstOrDefault<Album>( s => s.AlbumName == albumName );
			if( album == null )
			{
				db.Albums.Add( album = new Album( albumName ) );
			}

			return album.AlbumId;
		}
	}

	[Table( "Titles" )]
	public class Title
	{
		[Key] public int TitleId { get; set; }
		public string TitleName { get; set; } = string.Empty;

		public virtual ICollection<Track> Tracks { get; } = new HashSet<Track>();

		public Title()
		{
		}

		public Title( string titleName ) => TitleName = titleName;

		public static int Add( MusicLibrary db, string titleName )
		{
			Title? title = db.Titles.FirstOrDefault<Title>( s => s.TitleName == titleName );
			if( title == null )
			{
				db.Titles.Add( title = new Title( titleName ) );
			}

			return title.TitleId;
		}
	}

	[Table( "Tracks" )]
	public class Track
	{
		[Key] public int TrackId { get; set; }

		// The number of the track on the CD - 1 to 99, or 0 if not applicable
		public int TrackNumber { get; set; }
		// The disc number for a multi disc set
		public int DiscNumber { get; set; }
		// The number of discs in the multi disc set
		public int DiscCount { get; set; }

		// The year of release. 
		public int Year { get; set; }
		// The duration of the track in milliseconds
		public int Duration { get; set; }
		// The bit rate of the encoded file - typically over 128k
		public int BitRate { get; set; }
		// The sample rate of the audio. For CDs this is 44 kHz
		public int SampleRate { get; set; }
		// The size of the file in bytes
		public long Size { get; set; }

		// The foreign key into the Artists table
		public int ArtistId { get; set; }
		public virtual Artist? Artist { get; }

		// The foreign key into the Composers table
		public int ComposerId { get; set; }
		public virtual Composer? Composer { get; }

		// The foreign key into the Genres table
		public int GenreId { get; set; }
		public virtual Genre? Genre { get; }

		// The foreign key into the Albums table
		public int AlbumId { get; set; }
		public virtual Album? Album { get; }

		// The foreign key into the Titles table
		public int TitleId { get; set; }
		public virtual Title? Title { get; }
	}

	public class MusicLibrary
		: DbContext
	{
		// Define the tables in the relational database
		public DbSet<Artist> Artists { get; set; } = null!;
		public DbSet<Composer> Composers { get; set; } = null!;
		public DbSet<Genre> Genres { get; set; } = null!;
		public DbSet<Album> Albums { get; set; } = null!;
		public DbSet<Title> Titles { get; set; } = null!;
		public DbSet<Track> Tracks { get; set; } = null!;

		// Add a track to the database
		public void Add( Track track )
		{
			Tracks.Add( track );
		}
	}
}

#if false
	// Sample add to database
	using( MusicLibrary db = new MusicLibrary() )
	{
		Track track_entry = new Track();

		track_entry.TrackNumber = 6;
		track_entry.DiscNumber = 1;
		track_entry.DiscCount = 1;
		track_entry.Year = 1986;
		track_entry.Duration = 423000;
		track_entry.SampleRate = 44000;
		track_entry.BitRate = 128000;
		track_entry.Size = 6670000;

		track_entry.ArtistId = Artist.Add( db, "Fields of the Nephilim" );
		track_entry.ComposerId = Composer.Add( db, "Carl McCoy" );
		track_entry.GenreId = Genre.Add( db, "Goth" );
		track_entry.AlbumId = Album.Add( db, "Dawnrazor" );
		track_entry.TitleId = Title.Add( db, "Vet for the Insane" );
		db.Add( track_entry );
		db.SaveChanges();
	}
#endif