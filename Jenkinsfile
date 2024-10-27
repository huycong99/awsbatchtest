// Uses Declarative syntax to run commands inside a container.
pipeline {
    agent {
      label "kubeagent"
    }
    stages {
        stage('Git clone') {
            steps {
                git branch: 'master', url: 'https://github.com/huycong99/awsbatchtest.git'
            }
        }
    }
}
