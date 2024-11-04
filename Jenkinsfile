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
            
            writeFile file: '/kaniko/.docker/config.json', text: DOCKER_CONFIG_JSON
            sh 'echo "Building Docker image with Kaniko"'
            sh 'ls'
            sh 'cd /cache'
            sh 'echo "Hello, World!" | tee /cache/example.txt'
            sh 'ls'
            sh 'mkdir alo'


            sh '''
                /kaniko/executor --context `pwd` --dockerfile /home/jenkins/agent/workspace/CI_pipeline/TestAWSbatch/Dockerfile --build-arg AWS_REGION=$AWS_REGION --build-arg AWS_ACCESS_KEY_ID=$AWS_ACCESS_KEY_ID --build-arg AWS_SECRET_ACCESS_KEY=$AWS_SECRET_ACCESS_KEY --destination 056148863073.dkr.ecr.us-east-1.amazonaws.com/myecrtest:latest --cache=true --cache-dir=/cache --cache-repo=huycong011099/kaniko-cache
                  
            '''
            
            
        }

        }
    }
}
    }
}
