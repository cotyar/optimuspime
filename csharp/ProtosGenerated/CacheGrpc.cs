// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: cache.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace CalculationService {
  public static partial class DataSource
  {
    static readonly string __ServiceName = "calc.DataSource";

    static readonly grpc::Marshaller<global::CalculationService.DataSourceGetRequest> __Marshaller_calc_DataSourceGetRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CalculationService.DataSourceGetRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CalculationService.DataSourceGetResponse> __Marshaller_calc_DataSourceGetResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CalculationService.DataSourceGetResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::CalculationService.DataSourceGetRequest, global::CalculationService.DataSourceGetResponse> __Method_Get = new grpc::Method<global::CalculationService.DataSourceGetRequest, global::CalculationService.DataSourceGetResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "Get",
        __Marshaller_calc_DataSourceGetRequest,
        __Marshaller_calc_DataSourceGetResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CalculationService.CacheReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of DataSource</summary>
    [grpc::BindServiceMethod(typeof(DataSource), "BindService")]
    public abstract partial class DataSourceBase
    {
      public virtual global::System.Threading.Tasks.Task Get(global::CalculationService.DataSourceGetRequest request, grpc::IServerStreamWriter<global::CalculationService.DataSourceGetResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for DataSource</summary>
    public partial class DataSourceClient : grpc::ClientBase<DataSourceClient>
    {
      /// <summary>Creates a new client for DataSource</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public DataSourceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for DataSource that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public DataSourceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected DataSourceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected DataSourceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual grpc::AsyncServerStreamingCall<global::CalculationService.DataSourceGetResponse> Get(global::CalculationService.DataSourceGetRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Get(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::CalculationService.DataSourceGetResponse> Get(global::CalculationService.DataSourceGetRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_Get, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override DataSourceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new DataSourceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(DataSourceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Get, serviceImpl.Get).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, DataSourceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Get, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::CalculationService.DataSourceGetRequest, global::CalculationService.DataSourceGetResponse>(serviceImpl.Get));
    }

  }
  public static partial class CacheControl
  {
    static readonly string __ServiceName = "calc.CacheControl";

    static readonly grpc::Marshaller<global::CalculationService.CachePutRequest> __Marshaller_calc_CachePutRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CalculationService.CachePutRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CalculationService.CachePutResponse> __Marshaller_calc_CachePutResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CalculationService.CachePutResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CalculationService.CacheRemoveRequest> __Marshaller_calc_CacheRemoveRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CalculationService.CacheRemoveRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CalculationService.CacheRemoveResponse> __Marshaller_calc_CacheRemoveResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CalculationService.CacheRemoveResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CalculationService.CacheClearRequest> __Marshaller_calc_CacheClearRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CalculationService.CacheClearRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CalculationService.CacheClearResponse> __Marshaller_calc_CacheClearResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CalculationService.CacheClearResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::CalculationService.CachePutRequest, global::CalculationService.CachePutResponse> __Method_Put = new grpc::Method<global::CalculationService.CachePutRequest, global::CalculationService.CachePutResponse>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "Put",
        __Marshaller_calc_CachePutRequest,
        __Marshaller_calc_CachePutResponse);

    static readonly grpc::Method<global::CalculationService.CacheRemoveRequest, global::CalculationService.CacheRemoveResponse> __Method_Remove = new grpc::Method<global::CalculationService.CacheRemoveRequest, global::CalculationService.CacheRemoveResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Remove",
        __Marshaller_calc_CacheRemoveRequest,
        __Marshaller_calc_CacheRemoveResponse);

    static readonly grpc::Method<global::CalculationService.CacheClearRequest, global::CalculationService.CacheClearResponse> __Method_Clear = new grpc::Method<global::CalculationService.CacheClearRequest, global::CalculationService.CacheClearResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Clear",
        __Marshaller_calc_CacheClearRequest,
        __Marshaller_calc_CacheClearResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CalculationService.CacheReflection.Descriptor.Services[1]; }
    }

    /// <summary>Base class for server-side implementations of CacheControl</summary>
    [grpc::BindServiceMethod(typeof(CacheControl), "BindService")]
    public abstract partial class CacheControlBase
    {
      public virtual global::System.Threading.Tasks.Task<global::CalculationService.CachePutResponse> Put(grpc::IAsyncStreamReader<global::CalculationService.CachePutRequest> requestStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::CalculationService.CacheRemoveResponse> Remove(global::CalculationService.CacheRemoveRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::CalculationService.CacheClearResponse> Clear(global::CalculationService.CacheClearRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for CacheControl</summary>
    public partial class CacheControlClient : grpc::ClientBase<CacheControlClient>
    {
      /// <summary>Creates a new client for CacheControl</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public CacheControlClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for CacheControl that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public CacheControlClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected CacheControlClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected CacheControlClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual grpc::AsyncClientStreamingCall<global::CalculationService.CachePutRequest, global::CalculationService.CachePutResponse> Put(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Put(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncClientStreamingCall<global::CalculationService.CachePutRequest, global::CalculationService.CachePutResponse> Put(grpc::CallOptions options)
      {
        return CallInvoker.AsyncClientStreamingCall(__Method_Put, null, options);
      }
      public virtual global::CalculationService.CacheRemoveResponse Remove(global::CalculationService.CacheRemoveRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Remove(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::CalculationService.CacheRemoveResponse Remove(global::CalculationService.CacheRemoveRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Remove, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::CalculationService.CacheRemoveResponse> RemoveAsync(global::CalculationService.CacheRemoveRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RemoveAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::CalculationService.CacheRemoveResponse> RemoveAsync(global::CalculationService.CacheRemoveRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Remove, null, options, request);
      }
      public virtual global::CalculationService.CacheClearResponse Clear(global::CalculationService.CacheClearRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Clear(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::CalculationService.CacheClearResponse Clear(global::CalculationService.CacheClearRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Clear, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::CalculationService.CacheClearResponse> ClearAsync(global::CalculationService.CacheClearRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return ClearAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::CalculationService.CacheClearResponse> ClearAsync(global::CalculationService.CacheClearRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Clear, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override CacheControlClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new CacheControlClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(CacheControlBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_Put, serviceImpl.Put)
          .AddMethod(__Method_Remove, serviceImpl.Remove)
          .AddMethod(__Method_Clear, serviceImpl.Clear).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, CacheControlBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_Put, serviceImpl == null ? null : new grpc::ClientStreamingServerMethod<global::CalculationService.CachePutRequest, global::CalculationService.CachePutResponse>(serviceImpl.Put));
      serviceBinder.AddMethod(__Method_Remove, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CalculationService.CacheRemoveRequest, global::CalculationService.CacheRemoveResponse>(serviceImpl.Remove));
      serviceBinder.AddMethod(__Method_Clear, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CalculationService.CacheClearRequest, global::CalculationService.CacheClearResponse>(serviceImpl.Clear));
    }

  }
  /// <summary>
  /////////////////////////////////////////////
  /// Monitoring
  /////////////////////////////////////////////
  /// </summary>
  public static partial class MonitoringService
  {
    static readonly string __ServiceName = "calc.MonitoringService";

    static readonly grpc::Marshaller<global::CalculationService.MonitoringUpdateRequest> __Marshaller_calc_MonitoringUpdateRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CalculationService.MonitoringUpdateRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::CalculationService.MonitoringUpdateResponse> __Marshaller_calc_MonitoringUpdateResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::CalculationService.MonitoringUpdateResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::CalculationService.MonitoringUpdateRequest, global::CalculationService.MonitoringUpdateResponse> __Method_GetStatus = new grpc::Method<global::CalculationService.MonitoringUpdateRequest, global::CalculationService.MonitoringUpdateResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetStatus",
        __Marshaller_calc_MonitoringUpdateRequest,
        __Marshaller_calc_MonitoringUpdateResponse);

    static readonly grpc::Method<global::CalculationService.MonitoringUpdateRequest, global::CalculationService.MonitoringUpdateResponse> __Method_Subscribe = new grpc::Method<global::CalculationService.MonitoringUpdateRequest, global::CalculationService.MonitoringUpdateResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "Subscribe",
        __Marshaller_calc_MonitoringUpdateRequest,
        __Marshaller_calc_MonitoringUpdateResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CalculationService.CacheReflection.Descriptor.Services[2]; }
    }

    /// <summary>Base class for server-side implementations of MonitoringService</summary>
    [grpc::BindServiceMethod(typeof(MonitoringService), "BindService")]
    public abstract partial class MonitoringServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::CalculationService.MonitoringUpdateResponse> GetStatus(global::CalculationService.MonitoringUpdateRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task Subscribe(global::CalculationService.MonitoringUpdateRequest request, grpc::IServerStreamWriter<global::CalculationService.MonitoringUpdateResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for MonitoringService</summary>
    public partial class MonitoringServiceClient : grpc::ClientBase<MonitoringServiceClient>
    {
      /// <summary>Creates a new client for MonitoringService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public MonitoringServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for MonitoringService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public MonitoringServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected MonitoringServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected MonitoringServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::CalculationService.MonitoringUpdateResponse GetStatus(global::CalculationService.MonitoringUpdateRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetStatus(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::CalculationService.MonitoringUpdateResponse GetStatus(global::CalculationService.MonitoringUpdateRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetStatus, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::CalculationService.MonitoringUpdateResponse> GetStatusAsync(global::CalculationService.MonitoringUpdateRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetStatusAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::CalculationService.MonitoringUpdateResponse> GetStatusAsync(global::CalculationService.MonitoringUpdateRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetStatus, null, options, request);
      }
      public virtual grpc::AsyncServerStreamingCall<global::CalculationService.MonitoringUpdateResponse> Subscribe(global::CalculationService.MonitoringUpdateRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Subscribe(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::CalculationService.MonitoringUpdateResponse> Subscribe(global::CalculationService.MonitoringUpdateRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_Subscribe, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override MonitoringServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new MonitoringServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(MonitoringServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetStatus, serviceImpl.GetStatus)
          .AddMethod(__Method_Subscribe, serviceImpl.Subscribe).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, MonitoringServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetStatus, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::CalculationService.MonitoringUpdateRequest, global::CalculationService.MonitoringUpdateResponse>(serviceImpl.GetStatus));
      serviceBinder.AddMethod(__Method_Subscribe, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::CalculationService.MonitoringUpdateRequest, global::CalculationService.MonitoringUpdateResponse>(serviceImpl.Subscribe));
    }

  }
}
#endregion