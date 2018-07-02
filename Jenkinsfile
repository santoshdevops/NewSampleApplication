#!/bin/groovy


@Library('jenkins-global-lib')

import com.company.project.*

def util = new com.company.project.util()




def notifySuccess() {
		emailext (
			subject: "SUCCESSFUL: Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]'",
			body: '${JELLY_SCRIPT, template="html"}',
			mimeType: 'text/html',
			to: "santoshdevops@company.com",
			from: "DevOps COE <devops.local.smtp@gmail.com>",
			replyTo: "santoshdevops@company.com",
			//recipientProviders: [[$class: 'DevelopersRecipientProvider']]
		)
	}

	def notifyFailure() {
		emailext (
			subject: "Failure: Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]'",
			body: '${JELLY_SCRIPT, template="html"}',
			mimeType: 'text/html',
			to: "santoshdevops@company.com",
			from: "DevOps COE <devops.local.smtp@gmail.com>",
			replyTo: "santoshdevops@company.com",
			//recipientProviders: [[$class: 'DevelopersRecipientProvider']]
		)
	}

	def emailDownloadLink(String artifactUrl) {
		emailext (
			subject: "Build Release: Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]'",
			body: "URL: $artifactUrl",
			mimeType: 'text/html',
			to: "santoshdevops@company.com",
			from: "DevOps COE <devops.local.smtp@gmail.com>",
			replyTo: "santoshdevops@company.com",
			//recipientProviders: [[$class: 'DevelopersRecipientProvider']]
		)
	}


node {
       checkout scm
	data = readYaml file: 'input.yaml'
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
		     util.buildSourceCode(data.App.name, data.App.name2.prop3, data.App.name2.prop4) 
		     commitMessage = util.getCommitMessage()
		     #print data.App.name
		     #print data.App.name1.prop1
		     #print data.App.name1.prop2
		     #print data.App.name2.prop3
		     #print data.App.name2.prop4

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
        		notifyFailure()
        	}
        }
    }
}
