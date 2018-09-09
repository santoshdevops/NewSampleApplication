#!/bin/groovy


@Library('jenkins-global-lib')

import com.company.project.*
import org.yaml.snakeyaml.TypeDescription
import org.yaml.snakeyaml.Yaml
import org.yaml.snakeyaml.constructor.Constructor
import org.yaml.snakeyaml.nodes.Tag



import org.yaml.snakeyaml.Yaml;


def util = new com.company.project.util()


public void testLoadFromString() {
    Yaml yaml = new Yaml();
    String document = "hello: 25";
    Map map = (Map) yaml.load(document);
    assertEquals("{hello=25}", map.toString());
    assertEquals(new Long(25), map.get("hello"));
}

public void testLoadFromStream() throws FileNotFoundException {
    InputStream input = new FileInputStream(new File("input.yaml"));
    Yaml yaml = new Yaml();
    Object data1 = yaml.load(input);
		for (Object data1 : yaml.loadAll(input)) {
				assertNotNull(data1);
				assertTrue(data1.toString().length() > 1);
				counter++;
				print data1
		}
		input.close()
}





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
