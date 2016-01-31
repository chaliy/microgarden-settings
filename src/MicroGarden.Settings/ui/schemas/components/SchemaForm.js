import Form from '../../components/Form';
import TextField from '../../components/fields/TextField';
import JsonTextField from '../../components/fields/JsonTextField';

export default props => {

  var onSubmit = data => {
    if (props.onSubmit) {
      var schema = JSON.parse(data.schema);
      data.schema = schema;
      props.onSubmit(data);
    }
  };

  return (
    <Form {...props} onSubmit={onSubmit}>
      <TextField name="id"
          displayName="ID"
          required
          title="Lower case URL friendly id of the schema"
          help="URL friendly id of the schema to use all around."
          pattern="[a-z0-9]*"
          />
      <TextField name="displayName"
          displayName="Display Name" />

      <JsonTextField name="schema"
              displayName="Settings Schema" />
    </Form>
  );
};
