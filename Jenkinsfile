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
        stage('Kaniko build image'){
           steps {
               container('kaniko'){
                    sh 'echo "hello to kaniko container"'
                    sh '''
                    /kaniko/executor --context `pwd` --destination myecrtest:latest 056148863073.dkr.ecr.us-east-1.amazonaws.com/myecrtest:latest
                    '''
               }
               

           }
        }
    }
}
