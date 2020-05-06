package calc;

import static io.grpc.MethodDescriptor.generateFullMethodName;
import static io.grpc.stub.ClientCalls.asyncBidiStreamingCall;
import static io.grpc.stub.ClientCalls.asyncClientStreamingCall;
import static io.grpc.stub.ClientCalls.asyncServerStreamingCall;
import static io.grpc.stub.ClientCalls.asyncUnaryCall;
import static io.grpc.stub.ClientCalls.blockingServerStreamingCall;
import static io.grpc.stub.ClientCalls.blockingUnaryCall;
import static io.grpc.stub.ClientCalls.futureUnaryCall;
import static io.grpc.stub.ServerCalls.asyncBidiStreamingCall;
import static io.grpc.stub.ServerCalls.asyncClientStreamingCall;
import static io.grpc.stub.ServerCalls.asyncServerStreamingCall;
import static io.grpc.stub.ServerCalls.asyncUnaryCall;
import static io.grpc.stub.ServerCalls.asyncUnimplementedStreamingCall;
import static io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall;

/**
 * <pre>
 *&#47;/////////////////////////////////////////
 * Monitoring
 * //////////////////////////////////////////
 * </pre>
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.15.0)",
    comments = "Source: cache.proto")
public final class MonitoringServiceGrpc {

  private MonitoringServiceGrpc() {}

  public static final String SERVICE_NAME = "calc.MonitoringService";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<calc.Cache.MonitoringUpdateRequest,
      calc.Cache.MonitoringUpdateResponse> getGetStatusMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "GetStatus",
      requestType = calc.Cache.MonitoringUpdateRequest.class,
      responseType = calc.Cache.MonitoringUpdateResponse.class,
      methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
  public static io.grpc.MethodDescriptor<calc.Cache.MonitoringUpdateRequest,
      calc.Cache.MonitoringUpdateResponse> getGetStatusMethod() {
    io.grpc.MethodDescriptor<calc.Cache.MonitoringUpdateRequest, calc.Cache.MonitoringUpdateResponse> getGetStatusMethod;
    if ((getGetStatusMethod = MonitoringServiceGrpc.getGetStatusMethod) == null) {
      synchronized (MonitoringServiceGrpc.class) {
        if ((getGetStatusMethod = MonitoringServiceGrpc.getGetStatusMethod) == null) {
          MonitoringServiceGrpc.getGetStatusMethod = getGetStatusMethod = 
              io.grpc.MethodDescriptor.<calc.Cache.MonitoringUpdateRequest, calc.Cache.MonitoringUpdateResponse>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.UNARY)
              .setFullMethodName(generateFullMethodName(
                  "calc.MonitoringService", "GetStatus"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  calc.Cache.MonitoringUpdateRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  calc.Cache.MonitoringUpdateResponse.getDefaultInstance()))
                  .setSchemaDescriptor(new MonitoringServiceMethodDescriptorSupplier("GetStatus"))
                  .build();
          }
        }
     }
     return getGetStatusMethod;
  }

  private static volatile io.grpc.MethodDescriptor<calc.Cache.MonitoringUpdateRequest,
      calc.Cache.MonitoringUpdateResponse> getSubscribeMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "Subscribe",
      requestType = calc.Cache.MonitoringUpdateRequest.class,
      responseType = calc.Cache.MonitoringUpdateResponse.class,
      methodType = io.grpc.MethodDescriptor.MethodType.SERVER_STREAMING)
  public static io.grpc.MethodDescriptor<calc.Cache.MonitoringUpdateRequest,
      calc.Cache.MonitoringUpdateResponse> getSubscribeMethod() {
    io.grpc.MethodDescriptor<calc.Cache.MonitoringUpdateRequest, calc.Cache.MonitoringUpdateResponse> getSubscribeMethod;
    if ((getSubscribeMethod = MonitoringServiceGrpc.getSubscribeMethod) == null) {
      synchronized (MonitoringServiceGrpc.class) {
        if ((getSubscribeMethod = MonitoringServiceGrpc.getSubscribeMethod) == null) {
          MonitoringServiceGrpc.getSubscribeMethod = getSubscribeMethod = 
              io.grpc.MethodDescriptor.<calc.Cache.MonitoringUpdateRequest, calc.Cache.MonitoringUpdateResponse>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.SERVER_STREAMING)
              .setFullMethodName(generateFullMethodName(
                  "calc.MonitoringService", "Subscribe"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  calc.Cache.MonitoringUpdateRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  calc.Cache.MonitoringUpdateResponse.getDefaultInstance()))
                  .setSchemaDescriptor(new MonitoringServiceMethodDescriptorSupplier("Subscribe"))
                  .build();
          }
        }
     }
     return getSubscribeMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static MonitoringServiceStub newStub(io.grpc.Channel channel) {
    return new MonitoringServiceStub(channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static MonitoringServiceBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    return new MonitoringServiceBlockingStub(channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static MonitoringServiceFutureStub newFutureStub(
      io.grpc.Channel channel) {
    return new MonitoringServiceFutureStub(channel);
  }

  /**
   * <pre>
   *&#47;/////////////////////////////////////////
   * Monitoring
   * //////////////////////////////////////////
   * </pre>
   */
  public static abstract class MonitoringServiceImplBase implements io.grpc.BindableService {

    /**
     */
    public void getStatus(calc.Cache.MonitoringUpdateRequest request,
        io.grpc.stub.StreamObserver<calc.Cache.MonitoringUpdateResponse> responseObserver) {
      asyncUnimplementedUnaryCall(getGetStatusMethod(), responseObserver);
    }

    /**
     */
    public void subscribe(calc.Cache.MonitoringUpdateRequest request,
        io.grpc.stub.StreamObserver<calc.Cache.MonitoringUpdateResponse> responseObserver) {
      asyncUnimplementedUnaryCall(getSubscribeMethod(), responseObserver);
    }

    @java.lang.Override public final io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            getGetStatusMethod(),
            asyncUnaryCall(
              new MethodHandlers<
                calc.Cache.MonitoringUpdateRequest,
                calc.Cache.MonitoringUpdateResponse>(
                  this, METHODID_GET_STATUS)))
          .addMethod(
            getSubscribeMethod(),
            asyncServerStreamingCall(
              new MethodHandlers<
                calc.Cache.MonitoringUpdateRequest,
                calc.Cache.MonitoringUpdateResponse>(
                  this, METHODID_SUBSCRIBE)))
          .build();
    }
  }

  /**
   * <pre>
   *&#47;/////////////////////////////////////////
   * Monitoring
   * //////////////////////////////////////////
   * </pre>
   */
  public static final class MonitoringServiceStub extends io.grpc.stub.AbstractStub<MonitoringServiceStub> {
    private MonitoringServiceStub(io.grpc.Channel channel) {
      super(channel);
    }

    private MonitoringServiceStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected MonitoringServiceStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new MonitoringServiceStub(channel, callOptions);
    }

    /**
     */
    public void getStatus(calc.Cache.MonitoringUpdateRequest request,
        io.grpc.stub.StreamObserver<calc.Cache.MonitoringUpdateResponse> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(getGetStatusMethod(), getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void subscribe(calc.Cache.MonitoringUpdateRequest request,
        io.grpc.stub.StreamObserver<calc.Cache.MonitoringUpdateResponse> responseObserver) {
      asyncServerStreamingCall(
          getChannel().newCall(getSubscribeMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   * <pre>
   *&#47;/////////////////////////////////////////
   * Monitoring
   * //////////////////////////////////////////
   * </pre>
   */
  public static final class MonitoringServiceBlockingStub extends io.grpc.stub.AbstractStub<MonitoringServiceBlockingStub> {
    private MonitoringServiceBlockingStub(io.grpc.Channel channel) {
      super(channel);
    }

    private MonitoringServiceBlockingStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected MonitoringServiceBlockingStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new MonitoringServiceBlockingStub(channel, callOptions);
    }

    /**
     */
    public calc.Cache.MonitoringUpdateResponse getStatus(calc.Cache.MonitoringUpdateRequest request) {
      return blockingUnaryCall(
          getChannel(), getGetStatusMethod(), getCallOptions(), request);
    }

    /**
     */
    public java.util.Iterator<calc.Cache.MonitoringUpdateResponse> subscribe(
        calc.Cache.MonitoringUpdateRequest request) {
      return blockingServerStreamingCall(
          getChannel(), getSubscribeMethod(), getCallOptions(), request);
    }
  }

  /**
   * <pre>
   *&#47;/////////////////////////////////////////
   * Monitoring
   * //////////////////////////////////////////
   * </pre>
   */
  public static final class MonitoringServiceFutureStub extends io.grpc.stub.AbstractStub<MonitoringServiceFutureStub> {
    private MonitoringServiceFutureStub(io.grpc.Channel channel) {
      super(channel);
    }

    private MonitoringServiceFutureStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected MonitoringServiceFutureStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new MonitoringServiceFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<calc.Cache.MonitoringUpdateResponse> getStatus(
        calc.Cache.MonitoringUpdateRequest request) {
      return futureUnaryCall(
          getChannel().newCall(getGetStatusMethod(), getCallOptions()), request);
    }
  }

  private static final int METHODID_GET_STATUS = 0;
  private static final int METHODID_SUBSCRIBE = 1;

  private static final class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final MonitoringServiceImplBase serviceImpl;
    private final int methodId;

    MethodHandlers(MonitoringServiceImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_GET_STATUS:
          serviceImpl.getStatus((calc.Cache.MonitoringUpdateRequest) request,
              (io.grpc.stub.StreamObserver<calc.Cache.MonitoringUpdateResponse>) responseObserver);
          break;
        case METHODID_SUBSCRIBE:
          serviceImpl.subscribe((calc.Cache.MonitoringUpdateRequest) request,
              (io.grpc.stub.StreamObserver<calc.Cache.MonitoringUpdateResponse>) responseObserver);
          break;
        default:
          throw new AssertionError();
      }
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public io.grpc.stub.StreamObserver<Req> invoke(
        io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        default:
          throw new AssertionError();
      }
    }
  }

  private static abstract class MonitoringServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    MonitoringServiceBaseDescriptorSupplier() {}

    @java.lang.Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return calc.Cache.getDescriptor();
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("MonitoringService");
    }
  }

  private static final class MonitoringServiceFileDescriptorSupplier
      extends MonitoringServiceBaseDescriptorSupplier {
    MonitoringServiceFileDescriptorSupplier() {}
  }

  private static final class MonitoringServiceMethodDescriptorSupplier
      extends MonitoringServiceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    MonitoringServiceMethodDescriptorSupplier(String methodName) {
      this.methodName = methodName;
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.MethodDescriptor getMethodDescriptor() {
      return getServiceDescriptor().findMethodByName(methodName);
    }
  }

  private static volatile io.grpc.ServiceDescriptor serviceDescriptor;

  public static io.grpc.ServiceDescriptor getServiceDescriptor() {
    io.grpc.ServiceDescriptor result = serviceDescriptor;
    if (result == null) {
      synchronized (MonitoringServiceGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new MonitoringServiceFileDescriptorSupplier())
              .addMethod(getGetStatusMethod())
              .addMethod(getSubscribeMethod())
              .build();
        }
      }
    }
    return result;
  }
}
