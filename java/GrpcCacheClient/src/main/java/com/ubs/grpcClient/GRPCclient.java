/**
 * 
 */
package com.ubs.grpcClient;

import calc.Cache.CacheInvalidateRequest;
import calc.CacheControlGrpc;
import calc.CacheControlGrpc.CacheControlBlockingStub;
import calc.Moniker.MonikerId;
import calc.Moniker.MonikerVersionId;
import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;

/**
 * @author Murshid
 *
 */
public class GRPCclient {

	public static void main(String[] args) {

		System.out.println("****** Starting Client ********");
		ManagedChannel channel = ManagedChannelBuilder.forAddress("localhost", 9090).usePlaintext().build();

		CacheControlBlockingStub CacheControlStub = CacheControlGrpc.newBlockingStub(channel);
		MonikerVersionId MmonikerVersionId = MonikerVersionId.newBuilder().setVersion(new Long(1)).build();
		MonikerId id = MonikerId.newBuilder().setVersion(MmonikerVersionId).build();
		CacheInvalidateRequest cacheInvalidateRequest = CacheInvalidateRequest.newBuilder().setId(id).build();

		CacheControlStub.invalidate(cacheInvalidateRequest);
		
	}

}
