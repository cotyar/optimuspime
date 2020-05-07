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
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.15.0)",
    comments = "Source: cache.proto")
public final class DataSourceGrpc {

  private DataSourceGrpc() {}

  public static final String SERVICE_NAME = "calc.DataSource";

  // Static method descriptors that strictly reflect the proto.
  private static volatile io.grpc.MethodDescriptor<calc.Cache.DataSourceGetRequest,
      calc.Cache.DataSourceGetResponse> getGetMethod;

  @io.grpc.stub.annotations.RpcMethod(
      fullMethodName = SERVICE_NAME + '/' + "Get",
      requestType = calc.Cache.DataSourceGetRequest.class,
      responseType = calc.Cache.DataSourceGetResponse.class,
      methodType = io.grpc.MethodDescriptor.MethodType.SERVER_STREAMING)
  public static io.grpc.MethodDescriptor<calc.Cache.DataSourceGetRequest,
      calc.Cache.DataSourceGetResponse> getGetMethod() {
    io.grpc.MethodDescriptor<calc.Cache.DataSourceGetRequest, calc.Cache.DataSourceGetResponse> getGetMethod;
    if ((getGetMethod = DataSourceGrpc.getGetMethod) == null) {
      synchronized (DataSourceGrpc.class) {
        if ((getGetMethod = DataSourceGrpc.getGetMethod) == null) {
          DataSourceGrpc.getGetMethod = getGetMethod = 
              io.grpc.MethodDescriptor.<calc.Cache.DataSourceGetRequest, calc.Cache.DataSourceGetResponse>newBuilder()
              .setType(io.grpc.MethodDescriptor.MethodType.SERVER_STREAMING)
              .setFullMethodName(generateFullMethodName(
                  "calc.DataSource", "Get"))
              .setSampledToLocalTracing(true)
              .setRequestMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  calc.Cache.DataSourceGetRequest.getDefaultInstance()))
              .setResponseMarshaller(io.grpc.protobuf.ProtoUtils.marshaller(
                  calc.Cache.DataSourceGetResponse.getDefaultInstance()))
                  .setSchemaDescriptor(new DataSourceMethodDescriptorSupplier("Get"))
                  .build();
          }
        }
     }
     return getGetMethod;
  }

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static DataSourceStub newStub(io.grpc.Channel channel) {
    return new DataSourceStub(channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static DataSourceBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    return new DataSourceBlockingStub(channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary calls on the service
   */
  public static DataSourceFutureStub newFutureStub(
      io.grpc.Channel channel) {
    return new DataSourceFutureStub(channel);
  }

  /**
   */
  public static abstract class DataSourceImplBase implements io.grpc.BindableService {

    /**
     */
    public void get(calc.Cache.DataSourceGetRequest request,
        io.grpc.stub.StreamObserver<calc.Cache.DataSourceGetResponse> responseObserver) {
      asyncUnimplementedUnaryCall(getGetMethod(), responseObserver);
    }

    @java.lang.Override public final io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            getGetMethod(),
            asyncServerStreamingCall(
              new MethodHandlers<
                calc.Cache.DataSourceGetRequest,
                calc.Cache.DataSourceGetResponse>(
                  this, METHODID_GET)))
          .build();
    }
  }

  /**
   */
  public static final class DataSourceStub extends io.grpc.stub.AbstractStub<DataSourceStub> {
    private DataSourceStub(io.grpc.Channel channel) {
      super(channel);
    }

    private DataSourceStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected DataSourceStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new DataSourceStub(channel, callOptions);
    }

    /**
     */
    public void get(calc.Cache.DataSourceGetRequest request,
        io.grpc.stub.StreamObserver<calc.Cache.DataSourceGetResponse> responseObserver) {
      asyncServerStreamingCall(
          getChannel().newCall(getGetMethod(), getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class DataSourceBlockingStub extends io.grpc.stub.AbstractStub<DataSourceBlockingStub> {
    private DataSourceBlockingStub(io.grpc.Channel channel) {
      super(channel);
    }

    private DataSourceBlockingStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected DataSourceBlockingStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new DataSourceBlockingStub(channel, callOptions);
    }

    /**
     */
    public java.util.Iterator<calc.Cache.DataSourceGetResponse> get(
        calc.Cache.DataSourceGetRequest request) {
      return blockingServerStreamingCall(
          getChannel(), getGetMethod(), getCallOptions(), request);
    }
  }

  /**
   */
  public static final class DataSourceFutureStub extends io.grpc.stub.AbstractStub<DataSourceFutureStub> {
    private DataSourceFutureStub(io.grpc.Channel channel) {
      super(channel);
    }

    private DataSourceFutureStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected DataSourceFutureStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new DataSourceFutureStub(channel, callOptions);
    }
  }

  private static final int METHODID_GET = 0;

  private static final class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final DataSourceImplBase serviceImpl;
    private final int methodId;

    MethodHandlers(DataSourceImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_GET:
          serviceImpl.get((calc.Cache.DataSourceGetRequest) request,
              (io.grpc.stub.StreamObserver<calc.Cache.DataSourceGetResponse>) responseObserver);
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

  private static abstract class DataSourceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
    DataSourceBaseDescriptorSupplier() {}

    @java.lang.Override
    public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
      return calc.Cache.getDescriptor();
    }

    @java.lang.Override
    public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
      return getFileDescriptor().findServiceByName("DataSource");
    }
  }

  private static final class DataSourceFileDescriptorSupplier
      extends DataSourceBaseDescriptorSupplier {
    DataSourceFileDescriptorSupplier() {}
  }

  private static final class DataSourceMethodDescriptorSupplier
      extends DataSourceBaseDescriptorSupplier
      implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
    private final String methodName;

    DataSourceMethodDescriptorSupplier(String methodName) {
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
      synchronized (DataSourceGrpc.class) {
        result = serviceDescriptor;
        if (result == null) {
          serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
              .setSchemaDescriptor(new DataSourceFileDescriptorSupplier())
              .addMethod(getGetMethod())
              .build();
        }
      }
    }
    return result;
  }
}
