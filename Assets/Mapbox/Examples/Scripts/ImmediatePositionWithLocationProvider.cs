namespace Mapbox.Examples
{
	using Mapbox.Unity.Location;
	using Mapbox.Unity.Map;
	using UnityEngine;
	using MLAPI;
	using MLAPI.Messaging;
	using MLAPI.NetworkVariable;


	public class ImmediatePositionWithLocationProvider : MonoBehaviour
	{

		bool _isInitialized;

		ILocationProvider _locationProvider;
		ILocationProvider LocationProvider
		{
			get
			{
				if (_locationProvider == null)
				{
					_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
				}

				return _locationProvider;
			}
		}

		//was Position
		public NetworkVariableVector3 _targetPosition = new NetworkVariableVector3(new NetworkVariableSettings
		{
			WritePermission = NetworkVariablePermission.ServerOnly,
			ReadPermission = NetworkVariablePermission.Everyone
		});

		//Vector3 _targetPosition;
		void Start()
		{
			LocationProviderFactory.Instance.mapManager.OnInitialized += () => _isInitialized = true;
		}

		public void Move()
		{
			if (NetworkManager.Singleton.IsServer)
			{
				var map = LocationProviderFactory.Instance.mapManager;
				var targPosition = map.GeoToWorldPosition(LocationProvider.CurrentLocation.LatitudeLongitude);
				transform.position = targPosition;
				_targetPosition.Value = targPosition;
			}
			else
			{
				SubmitPositionRequestServerRpc();
			}
		}

			[ServerRpc]
			void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default)
			{
				var map = LocationProviderFactory.Instance.mapManager;
				_targetPosition.Value = map.GeoToWorldPosition(LocationProvider.CurrentLocation.LatitudeLongitude);
			}



			void LateUpdate()
			{
				if (_isInitialized)
				{

					transform.localPosition = _targetPosition.Value;
				}
			}
		}
	}
