package com.ubs.grpcServer;

import java.io.IOException;

import com.ubs.cacheService.CacheService;

import io.grpc.Server;
import io.grpc.ServerBuilder;

public class GRPCServer {
	
	public static void main(String[] args) throws IOException, InterruptedException {
		
		System.out.println("******* Starting Server ********");
		
		Server server = ServerBuilder.forPort(9090).addService(new CacheService()).build();
		
		server.start();
		
		System.out.println("******* Server stared ******** " + server.getPort());
		
		server.awaitTermination();
	}

}
