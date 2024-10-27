// Uses Declarative syntax to run commands inside a container.
pipeline {
    agent {
      label "kubeagent"
    }
    stages {
        stage('Git clone') {
            steps {
                git 'https://github.com/huycong99/awsbatchtest.git'
            }
        }
    }
}
