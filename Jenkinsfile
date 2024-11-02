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
            sh 'echo "Building Docker image with Kaniko"'
            sh 'cd TestAWSbatch'
            sh 'ls'
            sh '''
                /kaniko/executor --context `pwd` \
                                 --dockerfile /home/jenkins/agent/workspace/CI_pipeline/TestAWSbatch/Dockerfile \
                                 --destination 056148863073.dkr.ecr.us-east-1.amazonaws.com/myecrtest:latest \
                                 --no-push
            '''
        }
    }
}

stage('Push image to ECR') {
    steps {
        withCredentials([
            [$class: 'AmazonWebServicesCredentialsBinding', 
             credentialsId: "aws-jenkins", 
             accessKeyVariable: 'AWS_ACCESS_KEY_ID', 
             secretKeyVariable: 'AWS_SECRET_ACCESS_KEY']
        ]) {
            sh "aws ecr get-login-password --region us-east-1 | docker login --username AWS --password-stdin 056148863073.dkr.ecr.us-east-1.amazonaws.com"
            sh 'echo "Pushing image to ECR"'
            sh '''
                /kaniko/executor --context `pwd` \
                                 --dockerfile /home/jenkins/agent/workspace/CI_pipeline/TestAWSbatch/Dockerfile \
                                 --destination 056148863073.dkr.ecr.us-east-1.amazonaws.com/myecrtest:latest \
                                 --cache=true --push-only
            '''
        }
    }
}
    }
}
