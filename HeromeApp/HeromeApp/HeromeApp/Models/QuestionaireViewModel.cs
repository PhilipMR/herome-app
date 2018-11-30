using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HeromeApp.Models
{
	public class QuestionaireViewModel : INotifyPropertyChanged
	{
		#region Question model
		public class Question
		{
			public string Caption { get; set; }
			public List<string> Options { get; set; }
		}
		#endregion

		#region Result model
		public class Result
		{
			public List<int> Options { get; set; }
			public string Url { get; set; }
		}
		#endregion

		#region Events
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		#region Properties and fields
		public ObservableCollection<Question> Questions { get; }
		public ObservableCollection<Result> Results { get; }
		public Question ActiveQuestion { get; }
		#endregion

		#region Constructors
		public QuestionaireViewModel(List<Question> questions, List<Result> results)
		{
			if (questions.Count == 0)
			{
				throw new ArgumentException("The questions list contains no elements!");
			}
			if (results.Count == 0)
			{
				throw new ArgumentException("The results list contains no elements!");
			}
			this.Questions = new ObservableCollection<Question>(questions);
			this.Results = new ObservableCollection<Result>(results);

			this.ActiveQuestion = Questions[0];
			this.Questions.CollectionChanged += Questions_CollectionChanged;
			this.Results.CollectionChanged += Results_CollectionChanged;
		}
		#endregion

		#region Control events
		private void Questions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Questions)));
		}
		private void Results_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Results)));
		}
		#endregion
	}
}
