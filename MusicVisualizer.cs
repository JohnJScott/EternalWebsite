// Copyright Eternal Developments, LLC. All Rights Reserved.

using MusicDatabase;
using System.Windows.Forms.DataVisualization.Charting;

namespace WMAVisualizer
{
	public partial class MusicVisualizer : Form
	{
		public MusicVisualizer()
		{
			InitializeComponent();

			PopulateSeriesSongCountByYear();
			PopulateSeriesTracksByArtist();
			PopulateSeriesSongCountByGenre();
			PopulateSeriesBandsBySpecificGenre();
		}

		private void PopulateSeriesSongCountByYear()
		{
			MultiUseChart.Series.Clear();

			using( MusicLibrary db = new MusicLibrary() )
			{
				IEnumerable<IGrouping<int, Track>> group_tracks_by_year =
					from track in db.Tracks
					group track by track.Year;

				Series series = MultiUseChart.Series.Add( "Song count by year" );
				foreach( IGrouping<int, Track> year_track in group_tracks_by_year )
				{
					if( year_track.Key > 1960 && year_track.Key < 2030 )
					{
						series.Points.AddXY( year_track.Key, year_track.Count() );
					}
				}
			}

			MultiUseChart.SaveImage( "SongsByYear.png", ChartImageFormat.Png );
		}

		private void PopulateSeriesSongCountByGenre()
		{
			MultiUseChart.Series.Clear();

			using( MusicLibrary db = new MusicLibrary() )
			{
				IEnumerable<IGrouping<string, Genre>> group_tracks_by_genre =
					from genre in db.Genres
					join track in db.Tracks on genre.GenreId equals track.GenreId
					group genre by genre.GenreName;

				Series series = MultiUseChart.Series.Add( "Song count by genre" );
				foreach( IGrouping<string, Genre> genre_track in group_tracks_by_genre )
				{
					series.Points.AddXY( genre_track.Key, genre_track.Count() );
				}
			}

			MultiUseChart.SaveImage( "TracksByGenre.png", ChartImageFormat.Png );
		}

		private void PopulateSeriesBandsBySpecificGenre()
		{
			using( MusicLibrary db = new MusicLibrary() )
			{
				IEnumerable<Genre> genres =
					from genre in db.Genres
					select genre;

				foreach( Genre genre in genres )
				{
					MultiUseChart.Series.Clear();

					IEnumerable<IGrouping<string, Artist>> group_bands_by_genre =
						from track in db.Tracks
						where track.GenreId == genre.GenreId
						join artist in db.Artists on track.ArtistId equals artist.ArtistId
						group artist by artist.ArtistName;

					Series series = MultiUseChart.Series.Add( $"Song count by {genre.GenreName} genre" );
					foreach( IGrouping<string, Artist> rock_track in group_bands_by_genre )
					{
						series.Points.AddXY( rock_track.Key, rock_track.Count() );
					}

					MultiUseChart.SaveImage( $"BandsBy{genre.GenreName}Genre.png", ChartImageFormat.Png );
				}
			}
		}

		private void PopulateSeriesTracksByArtist()
		{
			MultiUseChart.Series.Clear();

			using( MusicLibrary db = new MusicLibrary() )
			{
				IQueryable<IGrouping<string, Artist>> tracks_by_artist =
					from artist in db.Artists
					join track in db.Tracks on artist.ArtistId equals track.ArtistId
					group artist by artist.ArtistName;

				tracks_by_artist = tracks_by_artist.Where( s => s.Count() > 10 ).OrderByDescending( s => s.Count() );

				Series series = MultiUseChart.Series.Add( "Song count by artist" );
				foreach( IGrouping<string, Artist> artist_track in tracks_by_artist )
				{
					series.Points.AddXY( artist_track.Key, artist_track.Count() );
				}
			}

			MultiUseChart.SaveImage( "TracksByArtist.png", ChartImageFormat.Png );
		}
	}
}