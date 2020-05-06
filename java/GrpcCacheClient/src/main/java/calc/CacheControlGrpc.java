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
@javax.annotation.Generated(value = "by gRPC proto compiler (version 1.15.0)", comments = "Source: cache.proto")
public final class CacheControlGrpc {

	private CacheControlGrpc() {
	}

	public static final String SERVICE_NAME = "calc.CacheControl";

	// Static method descriptors that strictly reflect the proto.
	private static volatile io.grpc.MethodDescriptor<calc.Cache.CacheInvalidateRequest, calc.Cache.CacheInvalidateResponse> getInvalidateMethod;

	@io.grpc.stub.annotations.RpcMethod(fullMethodName = SERVICE_NAME + '/'
			+ "Invalidate", requestType = calc.Cache.CacheInvalidateRequest.class, responseType = calc.Cache.CacheInvalidateResponse.class, methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
	public static io.grpc.MethodDescriptor<calc.Cache.CacheInvalidateRequest, calc.Cache.CacheInvalidateResponse> getInvalidateMethod() {
		io.grpc.MethodDescriptor<calc.Cache.CacheInvalidateRequest, calc.Cache.CacheInvalidateResponse> getInvalidateMethod;
		if ((getInvalidateMethod = CacheControlGrpc.getInvalidateMethod) == null) {
			synchronized (CacheControlGrpc.class) {
				if ((getInvalidateMethod = CacheControlGrpc.getInvalidateMethod) == null) {
					CacheControlGrpc.getInvalidateMethod = getInvalidateMethod = io.grpc.MethodDescriptor.<calc.Cache.CacheInvalidateRequest, calc.Cache.CacheInvalidateResponse>newBuilder()
							.setType(io.grpc.MethodDescriptor.MethodType.UNARY)
							.setFullMethodName(generateFullMethodName("calc.CacheControl", "Invalidate"))
							.setSampledToLocalTracing(true)
							.setRequestMarshaller(io.grpc.protobuf.ProtoUtils
									.marshaller(calc.Cache.CacheInvalidateRequest.getDefaultInstance()))
							.setResponseMarshaller(io.grpc.protobuf.ProtoUtils
									.marshaller(calc.Cache.CacheInvalidateResponse.getDefaultInstance()))
							.setSchemaDescriptor(new CacheControlMethodDescriptorSupplier("Invalidate")).build();
				}
			}
		}
		return getInvalidateMethod;
	}

	private static volatile io.grpc.MethodDescriptor<calc.Cache.CacheClearRequest, calc.Cache.CacheClearResponse> getClearMethod;

	@io.grpc.stub.annotations.RpcMethod(fullMethodName = SERVICE_NAME + '/'
			+ "Clear", requestType = calc.Cache.CacheClearRequest.class, responseType = calc.Cache.CacheClearResponse.class, methodType = io.grpc.MethodDescriptor.MethodType.UNARY)
	public static io.grpc.MethodDescriptor<calc.Cache.CacheClearRequest, calc.Cache.CacheClearResponse> getClearMethod() {
		io.grpc.MethodDescriptor<calc.Cache.CacheClearRequest, calc.Cache.CacheClearResponse> getClearMethod;
		if ((getClearMethod = CacheControlGrpc.getClearMethod) == null) {
			synchronized (CacheControlGrpc.class) {
				if ((getClearMethod = CacheControlGrpc.getClearMethod) == null) {
					CacheControlGrpc.getClearMethod = getClearMethod = io.grpc.MethodDescriptor.<calc.Cache.CacheClearRequest, calc.Cache.CacheClearResponse>newBuilder()
							.setType(io.grpc.MethodDescriptor.MethodType.UNARY)
							.setFullMethodName(generateFullMethodName("calc.CacheControl", "Clear"))
							.setSampledToLocalTracing(true)
							.setRequestMarshaller(io.grpc.protobuf.ProtoUtils
									.marshaller(calc.Cache.CacheClearRequest.getDefaultInstance()))
							.setResponseMarshaller(io.grpc.protobuf.ProtoUtils
									.marshaller(calc.Cache.CacheClearResponse.getDefaultInstance()))
							.setSchemaDescriptor(new CacheControlMethodDescriptorSupplier("Clear")).build();
				}
			}
		}
		return getClearMethod;
	}

	/**
	 * Creates a new async stub that supports all call types for the service
	 */
	public static CacheControlStub newStub(io.grpc.Channel channel) {
		return new CacheControlStub(channel);
	}

	/**
	 * Creates a new blocking-style stub that supports unary and streaming output
	 * calls on the service
	 */
	public static CacheControlBlockingStub newBlockingStub(io.grpc.Channel channel) {
		return new CacheControlBlockingStub(channel);
	}

	/**
	 * Creates a new ListenableFuture-style stub that supports unary calls on the
	 * service
	 */
	public static CacheControlFutureStub newFutureStub(io.grpc.Channel channel) {
		return new CacheControlFutureStub(channel);
	}

	/**
	 */
	public static abstract class CacheControlImplBase implements io.grpc.BindableService {

		/**
		 * <pre>
		 *rpc Put(stream CachePutRequest) returns (CachePutResponse) {}
		 * </pre>
		 */
		public void invalidate(calc.Cache.CacheInvalidateRequest request,
				io.grpc.stub.StreamObserver<calc.Cache.CacheInvalidateResponse> responseObserver) {
			asyncUnimplementedUnaryCall(getInvalidateMethod(), responseObserver);
		}

		/**
		 */
		public void clear(calc.Cache.CacheClearRequest request,
				io.grpc.stub.StreamObserver<calc.Cache.CacheClearResponse> responseObserver) {
			asyncUnimplementedUnaryCall(getClearMethod(), responseObserver);
		}

		@java.lang.Override
		public final io.grpc.ServerServiceDefinition bindService() {
			return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
					.addMethod(getInvalidateMethod(), asyncUnaryCall(
							new MethodHandlers<calc.Cache.CacheInvalidateRequest, calc.Cache.CacheInvalidateResponse>(
									this, METHODID_INVALIDATE)))
					.addMethod(getClearMethod(),
							asyncUnaryCall(
									new MethodHandlers<calc.Cache.CacheClearRequest, calc.Cache.CacheClearResponse>(
											this, METHODID_CLEAR)))
					.build();
		}
	}

	/**
	 */
	public static final class CacheControlStub extends io.grpc.stub.AbstractStub<CacheControlStub> {
		private CacheControlStub(io.grpc.Channel channel) {
			super(channel);
		}

		private CacheControlStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
			super(channel, callOptions);
		}

		@java.lang.Override
		protected CacheControlStub build(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
			return new CacheControlStub(channel, callOptions);
		}

		/**
		 * <pre>
		 *rpc Put(stream CachePutRequest) returns (CachePutResponse) {}
		 * </pre>
		 */
		public void invalidate(calc.Cache.CacheInvalidateRequest request,
				io.grpc.stub.StreamObserver<calc.Cache.CacheInvalidateResponse> responseObserver) {
			asyncUnaryCall(getChannel().newCall(getInvalidateMethod(), getCallOptions()), request, responseObserver);
		}

		/**
		 */
		public void clear(calc.Cache.CacheClearRequest request,
				io.grpc.stub.StreamObserver<calc.Cache.CacheClearResponse> responseObserver) {
			asyncUnaryCall(getChannel().newCall(getClearMethod(), getCallOptions()), request, responseObserver);
		}
	}

	/**
	 */
	public static final class CacheControlBlockingStub extends io.grpc.stub.AbstractStub<CacheControlBlockingStub> {
		private CacheControlBlockingStub(io.grpc.Channel channel) {
			super(channel);
		}

		private CacheControlBlockingStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
			super(channel, callOptions);
		}

		@java.lang.Override
		protected CacheControlBlockingStub build(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
			return new CacheControlBlockingStub(channel, callOptions);
		}

		/**
		 * <pre>
		 *rpc Put(stream CachePutRequest) returns (CachePutResponse) {}
		 * </pre>
		 */
		public calc.Cache.CacheInvalidateResponse invalidate(calc.Cache.CacheInvalidateRequest request) {
			return blockingUnaryCall(getChannel(), getInvalidateMethod(), getCallOptions(), request);
		}

		/**
		 */
		public calc.Cache.CacheClearResponse clear(calc.Cache.CacheClearRequest request) {
			return blockingUnaryCall(getChannel(), getClearMethod(), getCallOptions(), request);
		}
	}

	/**
	 */
	public static final class CacheControlFutureStub extends io.grpc.stub.AbstractStub<CacheControlFutureStub> {
		private CacheControlFutureStub(io.grpc.Channel channel) {
			super(channel);
		}

		private CacheControlFutureStub(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
			super(channel, callOptions);
		}

		@java.lang.Override
		protected CacheControlFutureStub build(io.grpc.Channel channel, io.grpc.CallOptions callOptions) {
			return new CacheControlFutureStub(channel, callOptions);
		}

		/**
		 * <pre>
		 *rpc Put(stream CachePutRequest) returns (CachePutResponse) {}
		 * </pre>
		 */
		public com.google.common.util.concurrent.ListenableFuture<calc.Cache.CacheInvalidateResponse> invalidate(
				calc.Cache.CacheInvalidateRequest request) {
			return futureUnaryCall(getChannel().newCall(getInvalidateMethod(), getCallOptions()), request);
		}

		/**
		 */
		public com.google.common.util.concurrent.ListenableFuture<calc.Cache.CacheClearResponse> clear(
				calc.Cache.CacheClearRequest request) {
			return futureUnaryCall(getChannel().newCall(getClearMethod(), getCallOptions()), request);
		}
	}

	private static final int METHODID_INVALIDATE = 0;
	private static final int METHODID_CLEAR = 1;

	private static final class MethodHandlers<Req, Resp> implements io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
			io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
			io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
			io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
		private final CacheControlImplBase serviceImpl;
		private final int methodId;

		MethodHandlers(CacheControlImplBase serviceImpl, int methodId) {
			this.serviceImpl = serviceImpl;
			this.methodId = methodId;
		}

		@java.lang.Override
		@java.lang.SuppressWarnings("unchecked")
		public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
			switch (methodId) {
			case METHODID_INVALIDATE:
				serviceImpl.invalidate((calc.Cache.CacheInvalidateRequest) request,
						(io.grpc.stub.StreamObserver<calc.Cache.CacheInvalidateResponse>) responseObserver);
				break;
			case METHODID_CLEAR:
				serviceImpl.clear((calc.Cache.CacheClearRequest) request,
						(io.grpc.stub.StreamObserver<calc.Cache.CacheClearResponse>) responseObserver);
				break;
			default:
				throw new AssertionError();
			}
		}

		@java.lang.Override
		@java.lang.SuppressWarnings("unchecked")
		public io.grpc.stub.StreamObserver<Req> invoke(io.grpc.stub.StreamObserver<Resp> responseObserver) {
			switch (methodId) {
			default:
				throw new AssertionError();
			}
		}
	}

	private static abstract class CacheControlBaseDescriptorSupplier
			implements io.grpc.protobuf.ProtoFileDescriptorSupplier, io.grpc.protobuf.ProtoServiceDescriptorSupplier {
		CacheControlBaseDescriptorSupplier() {
		}

		@java.lang.Override
		public com.google.protobuf.Descriptors.FileDescriptor getFileDescriptor() {
			return calc.Cache.getDescriptor();
		}

		@java.lang.Override
		public com.google.protobuf.Descriptors.ServiceDescriptor getServiceDescriptor() {
			return getFileDescriptor().findServiceByName("CacheControl");
		}
	}

	private static final class CacheControlFileDescriptorSupplier extends CacheControlBaseDescriptorSupplier {
		CacheControlFileDescriptorSupplier() {
		}
	}

	private static final class CacheControlMethodDescriptorSupplier extends CacheControlBaseDescriptorSupplier
			implements io.grpc.protobuf.ProtoMethodDescriptorSupplier {
		private final String methodName;

		CacheControlMethodDescriptorSupplier(String methodName) {
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
			synchronized (CacheControlGrpc.class) {
				result = serviceDescriptor;
				if (result == null) {
					serviceDescriptor = result = io.grpc.ServiceDescriptor.newBuilder(SERVICE_NAME)
							.setSchemaDescriptor(new CacheControlFileDescriptorSupplier())
							.addMethod(getInvalidateMethod()).addMethod(getClearMethod()).build();
				}
			}
		}
		return result;
	}
}
