// Copyright Eternal Developments, LLC. All Rights Reserved.

using System.Data.Entity.Core.Common.CommandTrees;
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
			PopulateSeriesBandsByGenre();
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
				series.ChartType = SeriesChartType.Pie;
				foreach( IGrouping<string, Genre> genre_track in group_tracks_by_genre )
				{
					if( genre_track.Count() > 50 )
					{
						series.Points.AddXY( genre_track.Key, genre_track.Count() );
					}
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

		private void PopulateSeriesBandsByGenre()
		{
			MultiUseChart.Series.Clear();

			using( MusicLibrary db = new MusicLibrary() )
			{
				// Create a list of pairs of GenreName and ArtistName
				var genres_and_artist =
					from artist in db.Artists
					join track in db.Tracks on artist.ArtistId equals track.ArtistId
					join genre in db.Genres on track.GenreId equals genre.GenreId
					group artist.ArtistName by genre.GenreName;

				// Count up the number of artists in each genre
				var genres_by_artist =
					from grouping in genres_and_artist
					select new
					{
						GenreName = grouping.Key,
						Artists = grouping.Distinct()
					};

				Series series = MultiUseChart.Series.Add( "Artist count by genre" );
				series.ChartType = SeriesChartType.Pie;
				foreach( var genre_artist in genres_by_artist )
				{
					if( genre_artist.Artists.Count() > 4 )
					{
						series.Points.AddXY( genre_artist.GenreName, genre_artist.Artists.Count() );
					}
				}
			}

			MultiUseChart.SaveImage( "BandsByGenre.png", ChartImageFormat.Png );
		}
	}
}