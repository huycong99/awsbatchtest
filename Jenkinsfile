// Uses Declarative syntax to run commands inside a container.
pipeline {
    agent {
      label "kubeagent"
    }
    stages {
        stage('Git clone') {
            steps {
                container('jlnp'){
                    git branch: 'main', url: 'https://github.com/huycong99/awsbatchtest.git'
                }
                
            }
        }
        
        stage('Kaniko build image') {
    steps {
        container('kaniko') {
            withCredentials([
            [$class: 'AmazonWebServicesCredentialsBinding', 
             credentialsId: "aws-jenkins", 
             accessKeyVariable: 'AWS_ACCESS_KEY_ID', 
             secretKeyVariable: 'AWS_SECRET_ACCESS_KEY']
        ]) {
            
            sh 'echo "Building Docker image with Kaniko"'
            sh 'ls'
            sh 'cd /cache'
            sh 'echo "Hello, World!" | sudo tee /cache/example.txt'
            sh 'ls'
            sh 'mkdir alo'
            
            
        }

        }
    }
}
    }
}
