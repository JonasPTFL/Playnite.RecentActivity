﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RecentActivity.Data.GameActivity
{
	public class Session : ObservableObject
	{
		private Guid _sourceId = default;
		private Guid _platformId = default;
		private List<Guid> _platformIDs = new List<Guid>();
		private int _idConfiguration = 0;
		private DateTime _dateSession = default;
		private int _elapsedSeconds = 0;

		public Guid SourceId { get => _sourceId; set => SetValue(ref _sourceId, value); }
		public Guid PlatfromId { get => _platformId; set => SetValue(ref _platformId, value); }
		public List<Guid> PlatformIDs { get => _platformIDs; set => SetValue(ref _platformIDs, value); }
		public int IdConfiguration { get => _idConfiguration; set => SetValue(ref _idConfiguration, value); }

		[JsonConverter(typeof(IsoDateTimeConverter))]
		public DateTime DateSession
		{
			get => _dateSession;
			set => SetValue(ref _dateSession, value.Kind == DateTimeKind.Utc ? value.ToLocalTime() : value);
		}

		public int ElapsedSeconds { get => _elapsedSeconds; set => SetValue(ref _elapsedSeconds, value); }
	}
}