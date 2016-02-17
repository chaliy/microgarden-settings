import Form from '../../components/Form';
import TextField from '../../components/fields/TextField';
import JsonTextField from '../../components/fields/JsonTextField';
import SchemaEditorField from './SchemaEditorField';

export default props => {

  return (
    <Form {...props} >
      <TextField name="id"
          displayName="ID"
          required
          title="Lower case URL friendly id of the schema"
          help="URL friendly id of the schema to use all around."
          pattern="[a-z0-9]*"
          />
      <TextField name="displayName"
          displayName="Display Name" />

      <SchemaEditorField name="schema"
              displayName="Settings Schema" />
    </Form>
  );
};
