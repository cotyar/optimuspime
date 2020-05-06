/**
 * 
 */
package com.ubs.cacheService;

import calc.Cache.CacheClearRequest;
import calc.Cache.CacheClearResponse;
import calc.Cache.CacheInvalidateRequest;
import calc.Cache.CacheInvalidateResponse;
import calc.CacheControlGrpc.CacheControlImplBase;
import io.grpc.stub.StreamObserver;

/**
 * @author Murshid
 *
 */
public class CacheService extends CacheControlImplBase {

	/*
	 * (non-Javadoc)
	 * 
	 * @see calc.CacheControlGrpc.CacheControlImplBase#invalidate(calc.Cache.
	 * CacheInvalidateRequest, io.grpc.stub.StreamObserver)
	 */
	@Override
	public void invalidate(CacheInvalidateRequest request, StreamObserver<CacheInvalidateResponse> responseObserver) {

		System.out.println("Inside invalidate");
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see calc.CacheControlGrpc.CacheControlImplBase#clear(calc.Cache.
	 * CacheClearRequest, io.grpc.stub.StreamObserver)
	 */
	@Override
	public void clear(CacheClearRequest request, StreamObserver<CacheClearResponse> responseObserver) {
		
		System.out.println("Inside clear");
		
	}

}
