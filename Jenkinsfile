#!/bin/groovy


@Library('jenkins-global-lib')

import com.company.project.*
import org.yaml.snakeyaml.TypeDescription
import org.yaml.snakeyaml.Yaml
import org.yaml.snakeyaml.constructor.Constructor
import org.yaml.snakeyaml.nodes.Tag

import org.yaml.snakeyaml.Yaml;
import org.json.simple.JSONValue;


def util = new com.company.project.util()


def notifySuccess() {
		emailext (
			subject: "SUCCESSFUL: Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]'",
			body: '${JELLY_SCRIPT, template="html"}',
			mimeType: 'text/html',
			to: "santosh.devops1@gmail.com",
			from: "DevOps COE <devops.local.smtp@gmail.com>",
			replyTo: "santosh.devops1@gmail.com",
			//recipientProviders: [[$class: 'DevelopersRecipientProvider']]
		)
	}

	def notifyFailure() {
		emailext (
			subject: "Failure: Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]'",
			body: '${JELLY_SCRIPT, template="html"}',
			mimeType: 'text/html',
			to: "santosh.devops1@gmail.com",
			from: "DevOps COE <devops.local.smtp@gmail.com>",
			replyTo: "santosh.devops1@gmail.com",
			//recipientProviders: [[$class: 'DevelopersRecipientProvider']]
		)
	}

	def emailDownloadLink(String artifactUrl) {
		emailext (
			subject: "Build Release: Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]'",
			body: "URL: $artifactUrl",
			mimeType: 'text/html',
			to: "santosh.devops1@gmail.com",
			from: "DevOps COE <devops.local.smtp@gmail.com>",
			replyTo: "santosh.devops1@gmail.com",
			//recipientProviders: [[$class: 'DevelopersRecipientProvider']]
		)
	}


	def function1(String[] args) throws FileNotFoundException {
	    Yaml yaml = new Yaml();
	    Reader yamlFile = new FileReader("./input1.yaml");


	    Map<String , Object> yamlMaps = (Map<String, Object>) yaml.load(yamlFile);

	    System.out.println(yamlMaps.get("App"));
	    final List<Map<String, Object>> module_name = (List<Map<String, Object>>) yamlMaps.get("components");
	    System.out.println(components);
	    System.out.println(components.get(0).get("prop1"));
	    System.out.println(components.get(1).get("prop1"));
	}



	private static String convertToJson(String yamlString) {
    Yaml yaml= new Yaml();
    Object obj = yaml.load(yamlString);
    return JSONValue.toJSONString(obj);
}




node {
       checkout scm
     }


pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

	stage('Build the source code') {
            steps {
		script {
		     echo "Building the source code  ... "
				 data = readYaml file: 'input.yaml'

				 print data.App.name1.prop1
				 print data.App.name1.prop2
				 print data.App.name2.prop3
				 print data.App.name2.prop4
				 print data.App.name3.prop5
				 print data.App.name3.prop6
         print "Hello"
		     print data.App.toString()
				 print data.App



         data123 = convertToJson("input.yml")
				 print data123


















	//			 @Grab(group='org.yaml', module='snakeyaml', version='1.13')

		   //  for(entry in data."${componentname}")
				 //{
					 //print $entry
				 //}


		     util.buildSourceCode(data.App.solution_file, data.App.project_file, data.App.app_dir)
		     commitMessage = util.getCommitMessage()

		}
		}
		}

	    stage ('Run the Unit Tests') {
	    	steps {
	    		script {
			        print "Executing the unit tests ... "
							function1()
		     		util.executeUnitTests()
			    }
	        }
	    }

	    stage ('Upload to Artifactory') {
	    	steps {
	    		script {
			        print "artifactory"
		     		util.uploadToArtifactory()
			    }
	        }
	    }
        stage('Deploy to Servers') {
            steps {
	    		script {
		     		util.deploy()
	        	}
            }
        }

}
	post {
        failure {
        	script {
        	print "mail"
					//notifyFailure()
        	}
        }
    }
}
